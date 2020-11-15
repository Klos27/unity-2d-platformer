<?php

function updateScore($con, $playerId, $worldId, $score)
{
    $stmt = $con->prepare("UPDATE points SET score = ? WHERE player_id = ? AND world_id = ?");
    $stmt->bind_param('iii', $score, $playerId, $worldId);

    try {
        $stmt->execute();
    } catch (Exception $e) {
        echo "Updating player score failed. Message: " . $e->getMessage() . "\n";
        $stmt->close();
        exit();
    } finally {
        $stmt->close();
    }
}

function insertScore($con, $playerId, $worldId, $score)
{
    $stmt = $con->prepare("INSERT INTO points (player_id, world_id, score) VALUES (?, ?, ?)");
    $stmt->bind_param('iii', $playerId, $worldId, $score);

    try {
        $stmt->execute();
    } catch (Exception $e) {
        echo "Creating player score failed. Message: " . $e->getMessage() . "\n";
        $stmt->close();
        exit();
    } finally {
        $stmt->close();
    }
}

function upsertScore($con, $playerId, $worldId, $score)
{
    $stmt = $con->prepare("SELECT player_id, world_id, score FROM points WHERE player_id = ? AND world_id = ?");
    $stmt->bind_param('ss', $playerId, $worldId);
    $stmt->execute();

    $result = $stmt->get_result();
    $stmt->close();

    if (mysqli_num_rows($result) == 1 and $score > $result->fetch_assoc()['score']) {
        updateScore($con, $playerId, $worldId, $score);
    } elseif (mysqli_num_rows($result) == 0 and $score > 0) {
        insertScore($con, $playerId, $worldId, $score);
    }
}

function main()
{
    include "databaseConnection.php";

    $con = getDatabaseConnection();
    $playerId = $_POST["playerId"];
    $worldId = $_POST["worldId"];
    $score = $_POST["score"];

    upsertScore($con, $playerId, $worldId, $score);

    echo "0";
    $con->close();
}

main();