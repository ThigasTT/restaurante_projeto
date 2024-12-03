<?php
if(isset($_POST['txt_nome'],$_POST['txt_email'],$_POST['dt_data'],$_POST['time_hórario'],$_POST['txt_end'],$_POST['mensagem'])){
    $name=$_POST['txt_nome'];
    $email=$_POST['txt_email'];
    $date=$_POST['dt_data'];
    $time=$_POST['time_hórario'];
    $end=$_POST['txt_end'];
    $mensa=$_POST['mensagem'];
    include_once "conexao.php";
    $stmt=$conn->prepare("insert into Pedido(Estabelecimento_idEstabelecimento,Nome_Cli,email,Data_reserva,Horario,N_Pessoas,Descrição_event)values(1,?,?,?,?,?,?)");
    $stmt->bindParam(1,$name);
    $stmt->bindParam(2,$email);
    $stmt->bindParam(3,$date);
    $stmt->bindParam(4,$time);
    $stmt->bindParam(5,$end);
    $stmt->bindParam(6,$mensa);
    
    if($stmt->execute()) {
        echo "Reserva feita com sucesso!";
    } else {
        echo "Erro ao realizar a reserva";
    }

}


?>

