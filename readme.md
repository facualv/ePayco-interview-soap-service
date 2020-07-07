# SOAP SERVICE VIRTUAL WALLET

Servicio Soap desarrollado en el marco de una entrevista tecnica para la empresa ePayco.
El servisio Soap se conecta con una base de datos local en MySql y provee las funcionalidades para simular una billetera electronica

## Stack Tecnológico

- .NET Framework 4.7.1
- ASMX Web Services

## API Endpoints

### POST /signup

Url: https://localhost:44348/SoapWebService.asmx?op=signIn

Ejemplo del cuerpo de la peticion y respuesta:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<signIn xmlns="http://tempuri.org/">
<clientId>string</clientId>
<name>string</name>
<phone>string</phone>
<email>string</email>
<password>string</password>
</signIn>
</soap12:Body>
</soap12:Envelope>

Ejemplo del cuerpo de la respuesta:

<?xml version="1.0" encoding="utf-8"?>

<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
<soap:Body>
<signInResponse xmlns="http://tempuri.org/">
<signInResult>
<Client>
<Messagge>string</Messagge>
<StatusCode>string</StatusCode>
<IsError>string</IsError>
<ClientId>string</ClientId>
<Name>string</Name>
<Phone>string</Phone>
<Email>string</Email>
<Password>string</Password>
</Client>
</signInResult>
</signInResponse>
</soap:Body>
</soap:Envelope>

### POST /login

Url: https://localhost:44348/SoapWebService.asmx?op=login

Ejemplo del cuerpo de la peticion:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<login xmlns="http://tempuri.org/">
<email>string</email>
<password>string</password>
</login>
</soap12:Body>
</soap12:Envelope>

Ejemplo de respuesta:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<loginResponse xmlns="http://tempuri.org/">
<loginResult>
<Client>
<Messagge>string</Messagge>
<StatusCode>string</StatusCode>
<IsError>string</IsError>
<ClientId>string</ClientId>
<Name>string</Name>
<Phone>string</Phone>
<Email>string</Email>
</Client>
</loginResult>
</loginResponse>
</soap12:Body>
</soap12:Envelope>

### POST /getBalance

Url: https://localhost:44348/SoapWebService.asmx?op=getBalance

Ejemplo del cuerpo de la peticion:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<getBalance xmlns="http://tempuri.org/">
<clientId>string</clientId>
<phone>string</phone>
</getBalance>
</soap12:Body>
</soap12:Envelope>

Ejemplo del cuerpo de la respuesta:

<CurrentBalanceBaseResponse xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://tempuri.org/">
<Messagge>string</Messagge>
<StatusCode>string</StatusCode>
<IsError>string</IsError>
<CurrentBalance>string</CurrentBalance>
</CurrentBalanceBaseResponse>

### POST /recharge

Url: https://localhost:44348/SoapWebService.asmx?op=recharge

Ejemplo del cuerpo de la peticion:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<recharge xmlns="http://tempuri.org/">
<clientId>string</clientId>
<phone>string</phone>
<ammount>decimal</ammount>
<detail>string</detail>
</recharge>
</soap12:Body>
</soap12:Envelope>

Ejemplo del cuerpo de la respuesta:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<rechargeResponse xmlns="http://tempuri.org/">
<rechargeResult>
<Messagge>string</Messagge>
<StatusCode>int</StatusCode>
<IsError>boolean</IsError>
</rechargeResult>
</rechargeResponse>
</soap12:Body>
</soap12:Envelope>

### POST /payment

Url: https://localhost:44348/SoapWebService.asmx?op=payment

Ejemplo del cuerpo de la peticion:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<payment xmlns="http://tempuri.org/">
<clientId>string</clientId>
<ammount>decimal</ammount>
<detail>string</detail>
</payment>
</soap12:Body>
</soap12:Envelope>

Ejemplo del cuerpo de la respuesta:

<?xml version="1.0" encoding="utf-8"?>

<soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
<soap12:Body>
<paymentResponse xmlns="http://tempuri.org/">
<paymentResult>
<Messagge>string</Messagge>
<StatusCode>int</StatusCode>
<IsError>boolean</IsError>
</paymentResult>
</paymentResponse>
</soap12:Body>
</soap12:Envelope>
