# SOAP SERVICE - BILLETERA VIRTUAL 

Servicio Soap desarrollado en el marco de una entrevista tecnica para la empresa ePayco.
El servisio Soap se conecta con una base de datos local en MySql y provee las funcionalidades para simular una billetera electronica

## Stack Tecnológico

- .NET Standard.Library v2.0.3
- .NET Framework 4.7.1
- EntityFrameworkCore v2.2.6 
- EntityFrameworkCore.Relational v2.2.6
- MySql.Data.EntityFrameworkCore 8.0.16

- ASMX Web Services

## Documentacion

https://documenter.getpostman.com/view/10747795/T17J9SjZ

## Endpoint del servicio

https://localhost:PORT/SoapWebService.asmx

## Metodos del Servicio

### signup
- Crea un cliente

### login
- Valida credenciales 

### getBalance
- Devuelve el balance actual de la billetera

### recharge
- Recarga el saldo de la billetera

### payment
- Realiza un pago
