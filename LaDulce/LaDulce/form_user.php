<?php
include_once "header.php";
?>
<form action="form.php" method="post">
    <label>Nome:</label><input type="text" name="txt_nome" required maxlength="100"><br>
    <label>Email:</label><input type="email" name="txt_email" required maxlength="100"><br>
    <label>Data De Reserva:</label><input type="date" name="dt_data" required><br>
    <label>N° De Pessoas:</label><input type="text" name="txt_end" required maxlength="100"><br>
    <textarea name="mensagem" id=""></textarea><br><input type="submit" value="Cadastrar" required>
   
</form>
<?php
include_once "footer.php";
?>
