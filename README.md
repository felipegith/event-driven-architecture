
<h3>Descrição</h3>
<p>Esta aplicação foi desenvolvida em .NET, seguindo os princípios da Clean Architecture e utilizando o padrão CQRS (Command Query Responsibility Segregation), para implementar uma arquitetura orientada a eventos (Event Driven Architecture). Quando um comando de pagamento é executado, um evento de integração é gerado e enviado para o RabbitMQ, permitindo que outras aplicações possam consumi-lo de forma assíncrona e reativa.</p>
