<?php
include_once "index.php";
?>

<style>
  #formm{
    height: 100vh;
  width: 100%;
  
  align-items: center;
  justify-content: center; margin-left: 650px;
  }


label {
    margin: 10px 0 5px 0;
}

input[type="text"],
input[type="email"],
textarea {
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    background-color: #444;
    color: #ffffff;
}

textarea {
    resize: vertical;
}

input[type="radio"] {
    margin-right: 10px;
}


input[type="submit"] {
    padding: 10px;
    border: none;
    border-radius: 5px;
    background-color: #ffc267;
    color: white;
    cursor: pointer;
    transition: background-color 0.3s;
}

input[type="submit"]:hover {
    background-color: #45a049;
}

</style>

<form id="formm" style="color:#ffffff;" action="ava_form.php" method="post">
    <h2>DEIXE AQUI SUA AVALIACÃO:</h2>
    <label>Nome:</label><input style="color: #ffffff; " type="text" name="txt_nome" placeholder="Digite seu Nome"><br>
    <label>Email:</label><input style="color: #ffffff;" type="email" name="txt_email" placeholder="Digite seu Email" required maxlength="100"><br>
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
  <input style="color: black;" type="submit" value="Enviar avaliação" required>
</form>
<?php
include_once "footer.php";
?>