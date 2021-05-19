# NRSoft.CloudBackup
云备份

## 部署命令

创建网络 nrsoft
````bash
docker network create nrsoft
````
部署MySql等中间件
````bash
docker-compose up -d
````

#### 使用DbMigrator应用程序应用迁移

该解决方案包含一个控制台应用程序(在此示例中名为`Acme.BookStore.DbMigrator`),可以创建数据库,应用迁移和初始化数据. 它对开发和生产环境都很有用.

> `.DbMigrator`项目有自己的`appsettings.json`. 因此,如果你更改了上面的连接字符串,则还应更改此字符串.

右键单击`.DbMigrator`项目并选择 **设置为启动项目**:

![set-as-startup-project](images/set-as-startup-project.png)

按F5(或Ctrl + F5)运行应用程序. 它将具有如下所示的输出:

![set-as-startup-project](images/db-migrator-app.png)


