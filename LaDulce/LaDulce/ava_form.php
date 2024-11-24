
<?php
if(isset($_POST['estrela'],$_POST['avaliacao'],$_POST['txt_nome'],$_POST['txt_email'])){
    $estrela=$_POST['estrela'];
    $avaliacao=$_POST['avaliacao'];
    $nome=$_POST['txt_nome'];
    $email=$_POST['txt_email'];
    include_once "conexao.php";

    $stmt=$conn->prepare("insert into Avaliacao(estrelas, avaliacao, nome, email)values(?,?,?,?)");
    $stmt->bindParam(1,$estrela);
    $stmt->bindParam(2,$avaliacao);
    $stmt->bindParam(3,$nome);
    $stmt->bindParam(4,$email);
    if($stmt->execute()) {
        echo "Avaliação enviada com sucesso!!!";
    } else {
        echo "Erro ao enviar sua avaliação, tente novamente mais tarde";
    }

}
