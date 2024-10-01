create database Restaurante;
use Restaurante;


CREATE TABLE Estabelecimento (
  idEstabelecimento INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  CEP INT NOT NULL,
  Tel_C INT NOT NULL,
  Propriétario VARCHAR(45) NOT NULL,
  CNPJ INT NOT NULL,
  PRIMARY KEY(idEstabelecimento)
);

CREATE TABLE Pedido (
  idPedido INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Pedido INT NOT NULL,
  Compra DOUBLE NOT NULL,
  Nome_cli VARCHAR(45) NOT NULL,
  Telefone_cli INT NOT NULL,
  Data_reserva DATE NOT NULL,
  N_Pessoas INT NOT NULL,
  Tipo_reserv VARCHAR(45) NOT NULL,
  Descrição_Event VARCHAR(45) NOT NULL,
  Status_2 VARCHAR(45) NOT NULL,
  PRIMARY KEY(idPedido, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Produtos (
  idProdutos INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Nome_P VARCHAR(45) NOT NULL,
  Validade DATE NOT NULL,
  Custo DOUBLE NOT NULL,
  PRIMARY KEY(idProdutos, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Recursos_Humanos (
  idRecursos_Humanos INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Nome VARCHAR(45) NOT NULL,
  Cargo VARCHAR(45) NOT NULL,
  Tel_C INT NOT NULL,
  Email VARCHAR(45) NOT NULL,
  Data_de_Contratação DATE NOT NULL,
  PRIMARY KEY(idRecursos_Humanos, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Fornecedores (
  idFornecedores INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Logadouro VARCHAR(45) NOT NULL,
  CNPJ INT NOT NULL,
  Complemento VARCHAR(45) NULL,
  CEP INT NOT NULL,
  Tel_C INT NOT NULL,
  Tempo_Contrato DATE NOT NULL,
  PRIMARY KEY(idFornecedores, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Estoque (
  idEstoque INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Quantidade_P INT NOT NULL,
  Custo_Unitário DOUBLE NOT NULL,
  Nome_P VARCHAR(45) NOT NULL,
  PRIMARY KEY(idEstoque, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Financeiro (
  idFinanceiro INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Financeiro DOUBLE NOT NULL,
  Despesas DOUBLE NOT NULL,
  Capital_Social DOUBLE NOT NULL,
  DRE DOUBLE NOT NULL,
  CMV DOUBLE NOT NULL,
  Salario_Fun DOUBLE NOT NULL,
  PRIMARY KEY(idFinanceiro, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Folha_Pag (
  idFolha_Pag INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Recursos_Humanos_idRecursos_Humanos INTEGER UNSIGNED NOT NULL,
  Recursos_Humanos_Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Salario DOUBLE NOT NULL,
  Faltas INT NOT NULL,
  Atrasos TIME NOT NULL,
  Hora_Extra TIME NOT NULL,
  Jornada_Mês INT NOT NULL,
  DSR INT NOT NULL,
  PRIMARY KEY(idFolha_Pag, Recursos_Humanos_idRecursos_Humanos, Recursos_Humanos_Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Recursos_Humanos_idRecursos_Humanos, Recursos_Humanos_Estabelecimento_idEstabelecimento)
    REFERENCES Recursos_Humanos(idRecursos_Humanos, Estabelecimento_idEstabelecimento)
);

