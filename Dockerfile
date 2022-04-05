#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DatabricksConnection/DatabricksConnection.csproj", "DatabricksConnection/"]
RUN dotnet restore "DatabricksConnection/DatabricksConnection.csproj"
COPY . .
WORKDIR "/src/DatabricksConnection"
RUN dotnet build "DatabricksConnection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatabricksConnection.csproj" -c Release -o /app/publish

#FROM ubuntu:focal as odbc
#ENV TZ=Europe/Paris
#RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
##RUN DEBIAN_FRONTEND=noninteractive TZ=Europe/Paris apt-get -y install tzdata
#RUN cp /usr/share/zoneinfo/Europe/Paris /etc/localtime
#ARG DEBIAN_FRONTEND=noninteractive
#RUN apt-get -o Acquire::Max-FutureTime=86400 update
#RUN apt-get update
#RUN apt-get install -y --no-install-recommends \
  #libpq-dev \
  #libxml2-dev \
  #ca-certificates \
  #unzip \
  #gdebi \
  #libssl-dev \
  #libcurl4-openssl-dev \
  #nano \
  #curl \
  #unixodbc \
  #unixodbc-dev
#### INSTALL databricks ODBC package
#RUN curl https://databricks-bi-artifacts.s3.us-east-2.amazonaws.com/simbaspark-drivers/odbc/2.6.17/SimbaSparkODBC-2.6.17.0024-Debian-64bit.zip -o SimbaSparkODBC-2.6.17.0024-Debian-64bit.zip && \
    #unzip SimbaSparkODBC-2.6.17.0024-Debian-64bit.zip -d tmp
#RUN gdebi -n  tmp/SimbaSparkODBC-2.6.17.0024-Debian-64bit/simbaspark_2.6.17.0024-2_amd64.deb
#RUN rm -r tmp/*
#RUN rm SimbaSparkODBC-2.6.17.0024-Debian-64bit.zip
#### CREATE ODBC.INI file
#RUN echo "[ODBC Data Sources]" >> /etc/odbc.ini && \
    #echo "Databricks_Cluster = Simba Spark ODBC Driver" >> /etc/odbc.ini && \
    #echo "" >> /etc/odbc.ini && \
    #echo "[Databricks_Cluster]" >> /etc/odbc.ini && \
    #echo "Driver          = /opt/simba/spark/lib/64/libsparkodbc_sb64.so" >> /etc/odbc.ini && \
    #echo "Description     = Simba Spark ODBC Driver DSN" >> /etc/odbc.ini && \
    #echo "HOST            = adb-5260914029640934.14.azuredatabricks.net" >> /etc/odbc.ini && \
    #echo "PORT            = 443" >> /etc/odbc.ini && \
    #echo "Schema          = default" >> /etc/odbc.ini && \
    #echo "SparkServerType = 3" >> /etc/odbc.ini && \
    #echo "AuthMech        = 3" >> /etc/odbc.ini && \
    ##echo "Auth_Flow       = 0" >> /etc/odbc.ini && \
    #echo "UID             = token" >> /etc/odbc.ini && \
    #echo "PWD             = dapid11332ace9475e25dc2cf390ddd01d15-2" >> /etc/odbc.ini && \
    #echo "ThriftTransport = 2" >> /etc/odbc.ini && \
    #echo "SSL             = 1" >> /etc/odbc.ini && \
    #echo "HTTPPath        = sql/protocolv1/o/5260914029640934/0128-145240-s994ywqz" >> /etc/odbc.ini && \
    ##echo "UseProxy        = 1" >> /etc/odbc.ini && \ 
    ##echo "ProxyHost       = $PROXY_HOST" >> /etc/odbc.ini && \ 
    ##echo "ProxyPort       = $PROXY_PORT" >> /etc/odbc.ini && \ 
    #echo "" >> /etc/odbc.ini && \
    #echo "[ODBC Drivers]" >> /etc/odbcinst.ini && \
    #echo "Simba = Installed" >> /etc/odbcinst.ini && \
    #echo "[Simba Spark ODBC Driver 64-bit]" >> /etc/odbcinst.ini && \
    #echo "Driver = /opt/simba/spark/lib/64/libsparkodbc_sb64.so" >> /etc/odbcinst.ini && \
    #echo "" >> /etc/odbcinst.ini

FROM base AS final
# Install Databricks ODBC driver.
RUN apt update && apt install -y unixodbc libodbc unixodbc-dev freetds-dev curl tdsodbc unzip libsasl2-modules-gssapi-mit
RUN curl -sL https://databricks.com/wp-content/uploads/drivers-2020/SimbaSparkODBC-2.6.16.1019-Debian-64bit.zip -o databricksOdbc.zip && unzip databricksOdbc.zip
RUN dpkg -i SimbaSparkODBC-2.6.16.1019-Debian-64bit/simbaspark_2.6.16.1019-2_amd64.deb
RUN export ODBCINI=/etc/odbc.ini ODBCSYSINI=/etc/odbcinst.ini SIMBASPARKINI=/opt/simba/spark/lib/64/simba.sparkodbc.ini
#COPY --from=odbc . .
COPY --from=publish /app/publish .
CMD ["bash", "entrypoint.sh"]