FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ARG NUGET_AUTH_TOKEN
ARG NUGET_USER_NAME

WORKDIR /app
COPY . ./

COPY ./nuget.config.template ./nuget.config
RUN sed -i -e "s/USER/$NUGET_USER_NAME/g" -e "s/PW/$NUGET_AUTH_TOKEN/g" nuget.config 

RUN dotnet restore "/app/Navistar.QuotesOrders.Api/Navistar.QuotesOrders.Api.csproj"
RUN dotnet publish "/app/Navistar.QuotesOrders.Api/Navistar.QuotesOrders.Api.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .
RUN apk add icu-libs --no-cache tzdata
RUN apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/
ENV TZ America/Mexico_City
EXPOSE 9097
ENTRYPOINT ["dotnet", "Navistar.QuotesOrders.Api.dll"]
