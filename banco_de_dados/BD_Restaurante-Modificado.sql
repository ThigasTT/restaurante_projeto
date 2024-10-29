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
INSERT INTO `restaurante`.`Estabelecimento` (`idEstabelecimento`, `CEP`, `Tel_C`, `Propriétario`, `CNPJ`) VALUES ('1', '21213232221', '117950584', 'Amandha', '00623904000173');


CREATE TABLE Pedido (
  idPedido INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Pedido varchar(45) NOT NULL,
  Compra DOUBLE NOT NULL,
  Nome_cli VARCHAR(45) NOT NULL,
  Telefone_cli VARCHAR(45) NOT NULL,
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
  Preço Double NOT NULL,
  Custo DOUBLE NOT NULL,
  PRIMARY KEY(idProdutos, Estabelecimento_idEstabelecimento)
);

INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('1', 'Grand Gateau', '79.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('2', 'Pudim', '22.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('3', 'Sundae Ponto A', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('4', 'Petit Gateau', '48.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('5', 'Taça Prestígio', '79.99');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('6', 'Ice Cream', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('7', 'Taça Oreo', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('8', 'Taça Ferrero Roche', '79.99');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('9', 'Merengue Francês', '32.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('10', 'Pastéis', '22.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('11', 'Dadinho de Tapioca', '29.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('12', 'Camarão na taça', '79.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('13', 'Fondue Salgado', '179.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('14', 'Fondue Doce', '149.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('15', 'Balada', '33.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('16', 'Bolinho de Costela', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('17', 'Tartar de Salmão', '39.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('18', 'Pastéis de Salmão', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('19', 'Bruschetta Queijo Brie', '29.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('20', 'Gin Royale', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('21', 'Paloma Dom Julio', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('22', 'Maracujá Premium', '54.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('23', 'Gramble Berry', '35.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('24', 'Bramble Black', '35.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('25', 'Ketel One', '34.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('26', 'Cereja Flor', '33.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('27', 'Gin Maça Verde', '49.90');
INSERT INTO `restaurante`.`Produtos` (`idProdutos`, `Nome_P`, `Preço`) VALUES ('28', 'Maragarita', '42.90');



CREATE TABLE Recursos_Humanos (
  idRecursos_Humanos INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Nome VARCHAR(45) NOT NULL,
  Cargo VARCHAR(45) NOT NULL,
  Tel_C VARCHAR(45) NOT NULL,
  Email VARCHAR(45) NOT NULL,
  Data_de_Contratação DATE NOT NULL,
  PRIMARY KEY(idRecursos_Humanos, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

INSERT INTO `restaurante`.`Recursos_Humanos` (`idRecursos_Humanos`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratação`) VALUES ('1', 'Rafael Santos', 'Garçom','(11)98754-4321','rafael.santos@restaurante.com','11/2/2022');
INSERT INTO `restaurante`.`Recursos_Humanos` (`idRecursos_Humanos`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratação`) VALUES ('2', 'Carlos Oliveira', 'Cozinheiro','(11)97654-3218','carlos.oliveira@restaurante.com','1/6/2022');
INSERT INTO `restaurante`.`Recursos_Humanos` (`idRecursos_Humanos`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratação`) VALUES ('3', 'Clara Silva', 'Gerente','(11)96543-3217','rafael.santos@restaurante.com','2/5/2023');
INSERT INTO `restaurante`.`Recursos_Humanos` (`idRecursos_Humanos`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratação`) VALUES ('4', 'Maria Pereira', 'Recepcionista','(11)95432-1678','maria.pereira@restaurante.com','10/12/2023');




CREATE TABLE Fornecedores (
  idFornecedores INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Logadouro VARCHAR(45) NOT NULL,
  CNPJ VARCHAR(45) NOT NULL,
  Complemento VARCHAR(45) NULL,
  CEP VARCHAR(45) NOT NULL,
  Tel_C VARCHAR(45) NOT NULL,
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
  /*CMV DOUBLE NOT NULL,*/
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
  PRIMARY KEY(idFolha_Pag, Recursos_Humanos_idRecursos_Humanos, Recursos_Humanos_Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Recursos_Humanos_idRecursos_Humanos, Recursos_Humanos_Estabelecimento_idEstabelecimento)
    REFERENCES Recursos_Humanos(idRecursos_Humanos, Estabelecimento_idEstabelecimento)
);

