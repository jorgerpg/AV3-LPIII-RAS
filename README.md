# RAS Manager

## Equipe 

Discentes (integrantes):

- Amanda Rigaud
- Felipe Ribeiro
- Guilherme Almeida
- Jorge Ricarte

Docente:

- Edson Mota da Cruz

Disciplina:

- Linguagem de Programação III

## Como acessar

**Clonando o repositório:**<br/>
1. Clique no botão de cor verde escrito "Code"
2. Copie a URL fornecida na aba Local > HTTPS
3. Abra o terminal no diretório desejado e digite o comando: `git clone https://github.com/Jorge2rpg/AV3-LPIII-RAS`

**Executando o projeto**<br/>
> Executando o Back-end

*Requisitos*: 
- [npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [MySQL](https://dev.mysql.com/downloads/installer/)

- [Nosso script MySQL](https://docs.google.com/document/d/17Ae6wyL0NVFgF1mbksu7tVYMInyjssj7VDAuagkcBpc/edit?usp=sharing)

1. Certifique-se de ter o Node.js, .NET Core SDK e o MySQL instalados em seu sistema, siga este para instalação do MySQL [passo-a-passo para instalação](https://youtu.be/KYaZVqHHXpM).
2. Após instalado o MySQL, abra o MySQL Workbench.
3. Crie uma nova conexão (de preferência com o usuário `root`).
4. Vá na aba `Server` e clique em `Data Import`.
5. Em `Import from Dump Project Folder`, selecione a pasta extraída do arquivo WinRar [que você deverá fazer download aqui](https://github.com/RAS-MANAGER/assets/blob/main/Dump20221113.rar).
6. Clique em `Load Folder Contents`. 
7. Deixe a conexão aberta e volte para o projeto que você clonou do Github.
8. Na pasta `server`, abra o arquivo `index.js`.
9. Neste arquivo, da linha 7 à linha 10, altere o que for necessário baseado nas configurações de sua conexão no MySQL Workbench.
10. Após as alterações, abra um terminal dentro do projeto e digite `cd server`.
11. Restaure as dependências do projeto, utilizando o comando `dotnet restore`.
12. Execute o comando `dotnet run` para iniciar o servidor backend.
13. O servidor backend será executado na porta 5000 .


> Executando o Front-End

*Requisitos*:
- [npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)

1. Abra um OUTRO terminal dentro do projeto (na raiz, **fora** da pasta **server**).
2. Instale as dependências do projeto: `npm install`
3. Digite `npm start`
4. Será aberta uma aba conectada ao `localhost:3000`.
5. Não é necessário fazer login. Clique em `Entrar`.
6. Telas conectadas ao banco de dados e funcionando: `Membros RAS`, `Eventos` e `Reuniões`.


---

# Especificações técnicas

- Front-End: ReactJS - NPM.
- Back-End: C# - .NET Core
- Banco de Dados: MySQL - RAS Manager

`ReactJS`: Framework Front-End<br/>
`C#`: Linguagem de programação para o Backend.<br/>
`MySQL (mysql2)`: Banco de Dados relacional que interage com o ExpressJS para manipulação e integração de dados.

Tecnologia | Status 
------ | ------
ReactJS | ✔ 
C#   | ✔ 
MySQL   | ✔

# Acessos

- Rotas para navegação entre telas: [Routes](src/Routes.js)
- Conexão com Banco de Dados (MySQL): [server](server/index.js)
