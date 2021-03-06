<?php

function insertPlayer($con, $login, $password, $email)
{
    $hashedPassword = password_hash($password, PASSWORD_DEFAULT);
    $stmt = $con->prepare("INSERT INTO player (login, password, email) VALUES (?, ?, ?)");
    $stmt->bind_param('sss', $login, $hashedPassword, $email);

    try {
        $stmt->execute();
    } catch (Exception $e) {
        echo "8: Creating new player failed. Message: " . $e->getMessage() . "\n";
        $stmt->close();
        exit();
    } finally {
        $stmt->close();
    }
}

function main()
{
    require_once "credentialConstraints.php";
    include "databaseConnection.php";
    include "credentialsValidator.php";

    $con = getDatabaseConnection();
    $login = $_POST["login"];
    $password = $_POST["password"];
    $repeatedPassword = $_POST["repeatedPassword"];
    $email = $_POST["email"];

    validateLogin($con, $login, $LOGIN_MIN_LENGTH, $LOGIN_MAX_LENGTH);
    validatePassword($password, $repeatedPassword, $PASSWORD_MIN_LENGTH);
    validateEmail($con, $email);
    insertPlayer($con, $login, $password, $email);

    echo "0";
    $con->close();
}

main();