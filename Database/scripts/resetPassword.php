<?php

function resetPassword($con, $login, $password)
{
    $hashedPassword = password_hash($password, PASSWORD_DEFAULT);
    $stmt = $con->prepare("UPDATE player SET password = ? WHERE login = ?");
    $stmt->bind_param('ss', $hashedPassword, $login);

    try {
        $stmt->execute();
    } catch (Exception $e) {
        echo "Changing player password failed. Message: " . $e->getMessage() . "\n";
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
    include "playerRepository.php";

    $con = getDatabaseConnection();
    $login = $_POST["login"];
    $password = $_POST["password"];
    $repeatedPassword = $_POST["repeatedPassword"];

    if (!playerExistsByLogin($con, $login)) {
        echo "Player with provided login does not exist";
        exit();
    }
    validatePassword($password, $repeatedPassword, $PASSWORD_MIN_LENGTH);
    resetPassword($con, $login, $password);

    echo "0";
    $con->close();
}

main();