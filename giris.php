<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Anton&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="girisForm.css">
</head>

<body> 

  
    <?php
        $kullanici = $_POST['Kullanıcı'];
        $sifre = $_POST['sifre'];
        $gercekKullanici = "g221210040@sakarya.edu.tr";
        $gercekSifre = "g221210040";

        if($kullanici == $gercekKullanici && $sifre == $gercekSifre){
            echo "<h1>Giriş Başarılı. Hoşgeldiniz $kullanici </h1>";
            echo "<script>setTimeout(function(){window.location.href='hakkimda.html'}, 2000);</script>";
        }

        else{
                echo "<h1>Kullanıcı adı veya şifre hatalı</h1>";
                echo "<script>setTimeout(function(){window.location.href='giris.html'}, 2000);</script>";
    }



    ?>
    
</body>

</html>