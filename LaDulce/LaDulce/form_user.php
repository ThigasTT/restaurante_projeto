<?php
include_once "header.php";
?>
<style>
  @import url('https://fonts.googleapis.com/css2?family=Funnel+Display:wght@300..800&family=Oleo+Script&display=swap'); 
  *{
 
  font-family: "Funnel Display", sans-serif;
  font-optical-sizing: auto;
  font-weight: <weight>;
  font-style: normal;
}
  


</style>
<form action="form.php" method="post">
    <label class="header-p">Nome:</label><input type="text" name="txt_nome" placeholder="Digite Seu Nome" required maxlength="100"><br>
    <label class="header-p">Email:</label><input type="email" name="txt_email" placeholder="Digite Seu Email" required maxlength="100"><br>
    <label class="header-p">Data De Reserva:</label><input type="date" name="dt_data" required><br>
    <label class="header-p">N° De Pessoas:</label><input type="text" name="txt_end" placeholder="Numero de Pessoas" required maxlength="100"><br>
    <textarea placeholder="Digite sua mensagem aqui"  name="mensagem"></textarea><br><input style="color:black; background-color:  #ffc267;"  class="header-p" type="submit" value="Cadastrar" required>
</form>
<?php
include_once "footer.php";
?>
