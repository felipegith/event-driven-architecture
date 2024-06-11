
<h3>Descrição</h3>
<p>Esta aplicação foi desenvolvida em .NET, seguindo os princípios da Clean Architecture e utilizando o padrão CQRS (Command Query Responsibility Segregation), para implementar uma arquitetura orientada a eventos (Event Driven Architecture). Quando um comando de pagamento é executado, um evento de integração é gerado e enviado para o RabbitMQ, permitindo que outras aplicações possam consumi-lo de forma assíncrona e reativa.</p>

<h3>Estrutura do Projeto</h3>
<p>A estrutura do projeto é organizada de acordo com os princípios da Clean Architecture, separando claramente as diferentes responsabilidades e camadas da aplicação.</p>
<ul>
  <li>Domain: Contém as entidades, interfaces e regras de negócio.</li>
  <li>Application: Contém os casos de uso, comandos, consultas e a implementação do padrão CQRS..</li>
  <li>Infrastructure: Contém as implementações específicas de infraestrutura, como repositórios, serviços de integração com o RabbitMQ, e configurações de banco de dados..</li>
  <li>Presentation: Contém a API ou interface com o usuário, controladores e endpoints.</li>
  <li>Integration: Contém a inteface do evento e a classe do evento de integração</li>
</ul>


