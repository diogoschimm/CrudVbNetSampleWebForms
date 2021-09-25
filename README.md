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
