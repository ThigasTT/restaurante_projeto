create database Restaurante;
use Restaurante;

CREATE TABLE Estabelecimento (
  idEstabelecimento INTEGER,
  CEP varchar(50) not NULL,
  Tel_C varchar(23) NOT NULL,
  Propriétario VARCHAR(45) NOT NULL,
  CNPJ varchar(16) NOT NULL,
  PRIMARY KEY(idEstabelecimento)
);
INSERT INTO `restaurante`.`Estabelecimento` (`idEstabelecimento`, `CEP`, `Tel_C`, `Propriétario`, `CNPJ`) VALUES ('1', '21213232221', '117950584', 'Amandha', '00623904000173');
CREATE TABLE Avaliacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    estrelas INT NOT NULL CHECK (estrelas >= 1 AND estrelas <= 5),
    avaliacao VARCHAR(250) not null,
    nome varchar(60) not null,
    email varchar(80) not null
);

CREATE TABLE Pedido (
  idPedido INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER,
  Pedido varchar(45),
  Compra DOUBLE ,
  Nome_cli VARCHAR(45) ,
  email varchar(80) ,
  Telefone_cli VARCHAR(45) ,
  Data_reserva DATE ,
  N_Pessoas INT ,
  Tipo_reserv VARCHAR(45) ,
  Descrição_Event VARCHAR(45) ,
  Status_2 VARCHAR(45) ,
  PRIMARY KEY(idPedido),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Produtos (
  idProdutos INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER UNSIGNED NOT NULL,
  Nome_P VARCHAR(45) NOT NULL,
  Validade DATE NOT NULL,
  Quantidade int not null,
  Preço Double NOT NULL,
  Custo DOUBLE NOT NULL,
  Saldo double not null,
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


CREATE TABLE Funcionario (
  idFuncionario INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idEstabelecimento INTEGER ,
  Nome VARCHAR(45) NOT NULL,
  Cargo VARCHAR(45) NOT NULL,
  Tel_C VARCHAR(45) NOT NULL,
  Email VARCHAR(45) NOT NULL,
  Data_de_Contratacao varchar(45) NOT NULL,
  PRIMARY KEY(idFuncionario),
  foreign key (idEstabelecimento) references Estabelecimento (idEstabelecimento)
);

INSERT INTO `restaurante`.`Funcionario` (`idFuncionario`,`idEstabelecimento`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratacao`) VALUES ('1','1', 'Rafael Santos', 'Garçom','(11)98754-4321','rafael.santos@restaurante.com','11/2/2022');
INSERT INTO `restaurante`.`Funcionario` (`idFuncionario`,`idEstabelecimento`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratacao`) VALUES ('2','1', 'Carlos Oliveira', 'Cozinheiro','(11)97654-3218','carlos.oliveira@restaurante.com','1/6/2022');
INSERT INTO `restaurante`.`Funcionario` (`idFuncionario`,`idEstabelecimento`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratacao`) VALUES ('3','1', 'Clara Silva', 'Gerente','(11)96543-3217','rafael.santos@restaurante.com','2/5/2023');
INSERT INTO `restaurante`.`Funcionario` (`idFuncionario`,`idEstabelecimento`, `Nome`, `Cargo`,`Tel_C`,`Email`,`Data_de_Contratacao`) VALUES ('4','1', 'Maria Pereira', 'Recepcionista','(11)95432-1678','maria.pereira@restaurante.com','10/12/2023');




CREATE TABLE Fornecedores (
  idFornecedores INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER ,
  Nome varchar(45) not null,
  Logradouro VARCHAR(45) NOT NULL,
  CNPJ VARCHAR(45) NOT NULL,
  Complemento VARCHAR(45) NULL,
  CEP VARCHAR(45) NOT NULL,
  Tel_C VARCHAR(45) NOT NULL,
  Tempo_Contrato varchar(10) NOT NULL,
  PRIMARY KEY(idFornecedores, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

insert into Fornecedores values(1,1,'fornecedor1','rua','12345678','casa1','0000000','00000-0000',0000-00-00);

CREATE TABLE Estoque (
  idEstoque INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER,
  Quantidade_P INT NOT NULL,
  Custo_Unitário DOUBLE NOT NULL,
  Nome_P VARCHAR(45) NOT NULL,
  PRIMARY KEY(idEstoque, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

CREATE TABLE Financeiro (
  idFinanceiro INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Estabelecimento_idEstabelecimento INTEGER ,
  Ativo DOUBLE  NOT NULL,
  Passivo DOUBLE  NOT NULL,
  Capital_Social DOUBLE NOT NULL,
  DRE DOUBLE NOT NULL,
  /*CMV DOUBLE NOT NULL,*/
  Salario_Fun DOUBLE NOT NULL,
  Caixa DOUBLE NOT NULL,
  Estoque DOUBLE NOT NULL,
  Compras_prazo DOUBLE NOT NULL,
  Emprestimos DOUBLE NOT NULL,
  PRIMARY KEY(idFinanceiro, Estabelecimento_idEstabelecimento),
  FOREIGN KEY(Estabelecimento_idEstabelecimento)
    REFERENCES Estabelecimento(idEstabelecimento)
);

insert into `restaurante`.`financeiro`(`idFinanceiro`,`Estabelecimento_idEstabelecimento`,`Capital_Social`) values(1,1,15.000);

CREATE TABLE Folha_Pag (
  idFolha_Pag INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idFuncionario INTEGER UNSIGNED NOT NULL,
  idEstabelecimento INTEGER ,
  Salario_base DECIMAL NOT NULL,
  Salario_final DECIMAL NOT NULL,
  Faltas INT NOT NULL,
  Atrasos DECIMAL NOT NULL,
  Hora_Extra DECIMAL NOT NULL,
  Jornada_Mes INT NOT NULL,
  PRIMARY KEY(idFolha_Pag),
  foreign key(idFuncionario) references Funcionario(idFuncionario)
);