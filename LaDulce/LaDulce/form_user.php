<?php
include_once "header.php";
?>
<form action="form.php" method="post">
    <label class="header-p">Nome:</label><input type="text" name="txt_nome" required maxlength="100"><br>
    <label class="header-p">Email:</label><input type="email" name="txt_email" required maxlength="100"><br>
    <label class="header-p">Data De Reserva:</label><input type="date" name="dt_data" required><br>
    <label class="header-p">N° De Pessoas:</label><input type="text" name="txt_end" required maxlength="100"><br>
    <textarea name="mensagem" id=""></textarea><br><input class="header-p" type="submit" value="Cadastrar" required>
   
</form>
<?php
include_once "footer.php";
?>
