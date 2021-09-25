# Crud Vb.Net Sample WebForms
CRUD em VB.NET de Exemplo para Sistemas Legados

- Troque a string de conexão no arquivo web.config do projeto web

```xml
 <add name="ConnectionStringBase" 
      connectionString="Data Source=<<HostName>>\<<InstanceName>>;
			Initial Catalog=DbVendasSample;
			Integrated Security=SSPI;"/>
```

## Script do banco de dados

- Utilize o script abaixo para o banco de dados no SQL Server

```tsql
CREATE DATABASE DbVendasSample;
GO
USE DbVendasSample;
GO
CREATE TABLE Clientes
(
	idCliente int not null primary key identity(1, 1), 
	nomeCliente varchar(100),
	documentoCliente varchar(14)
)
```

## Estrutura do Projeto

![image](https://user-images.githubusercontent.com/30643035/134756611-9c8f244a-90c7-4508-9b64-f3d64a6998c4.png)

