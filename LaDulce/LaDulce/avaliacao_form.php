<?php
include_once "index.php";
?>


<form style="margin: 15px; color:#ffffff; background-color : red;  " action="ava_form.php" method="post">
    <p>DEIXE AQUI SUA AVALIACÃO:</p>
    <label>Nome:</label><input style="color: #ffffff; " type="text" name="txt_nome" required><br>
    <label>Email:</label><input style="color: #ffffff;" type="email" name="txt_email" required maxlength="100"><br>
    <input type="radio" id="1" name="estrela" value="1">
  <label for="1">⭐</label><br>
  <input type="radio" id="2" name="estrela" value="2">
  <label for="2">⭐⭐</label><br>
  <input type="radio" id="3" name="estrela" value="3">
  <label for="3">⭐⭐⭐</label><br>
  <input type="radio" id="4" name="estrela" value="4">
  <label for="4">⭐⭐⭐⭐</label><br>
  <input type="radio" id="5" name="estrela" value="5">
  <label for="5">⭐⭐⭐⭐⭐</label><br>
  <textarea style="color: #ffffff;" name="avaliacao" id="" placeholder="Comente aqui"></textarea><br>
  <input style="color: #ffffff;" type="submit" value="Enviar avaliação" required>
</form>
<?php
include_once "footer.php";
?>