<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Anton&display=swap" rel="stylesheet">
    <!-- <link rel="stylesheet" href="iletisimForm.css"> -->
</head>
<body>

<?php
    // Check if form is submitted
    if($_SERVER["REQUEST_METHOD"] == "POST") {
        $name = $_POST['name'];
        $email = $_POST['email'];
        $birthdate = $_POST['birthdate'];
        $phone = $_POST['phone'];
        $gender = $_POST['gender'];
        $message = $_POST['message'];

        // Print the data
        echo "Name: $name<br>";
        echo "Email: $email<br>";
        echo "Birthdate: $birthdate<br>";
        echo "Phone: $phone<br>";
        echo "Gender: $gender<br>";
        echo "Message: $message<br>";
    } else {
        // Not a POST request, set a 403 (forbidden) response code.
        http_response_code(403);
    }
?>

    






    
</body>
</html>