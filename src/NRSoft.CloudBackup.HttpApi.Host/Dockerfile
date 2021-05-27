# 此Dockerfile文件为发布后生成docker镜像
# docker build -t cloudbackup .
# docker run -it --restart=always --rm -p 6080:80 --name cloudbackup cloudbackup

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY . .
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "NRSoft.CloudBackup.HttpApi.Host.dll"]