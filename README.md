# VagasCom API

Teste Backend da empresa VagasCom
## Requerimentos

 1. Ter instalado Docker
 2. Ter Instalado VSCode ou Visual Studio
 4. Ter Instalado Git
 5. Ter Instalado Postman


## Pasos

1. Clonar o Repositorio tudo com Git
2. configurar os arquivos Dockerfile e docker-compose.yml para ter acessos aos portos se for o caso
3. ir na raiz do projeto e executar o comando "docker-compose up -d" para criar o container e começar a funcionar
4. verificar o console do docker que o serviço rodou corretamente, ignorar mensagens de configuração de SSL
5. Pode usar o arquivo VagasCom.postman_collection.json dentro da raiz do projeto para importar no postman a collection para chamar o serviço
6. em alguns casos pode acontecer que a hora do container esta diferente da do host, nesse caso é so reiniciar o serviço de docker




