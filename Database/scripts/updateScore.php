<?php

	function updateScore($con, $playerId, $worldId, $score) {
		$updateScoreQuery = $con->prepare("UPDATE points SET score = ? WHERE player_id = ? AND world_id = ?");
		$updateScoreQuery->bind_param('iii', $score, $playerId, $worldId);
		
		try {
			$updateScoreQuery->execute();
		} catch (Exception $e) {
			echo "2: Updating player score failed. Message: " . $e->getMessage() . "\n";
			$updateScoreQuery->close();
			exit();
		} finally {
			$updateScoreQuery->close();
		}
	}
	
	function insertScore($con, $playerId, $worldId, $score) {		
		$insertScoreQuery = $con->prepare("INSERT INTO points (player_id, world_id, score) VALUES (?, ?, ?)");
		$insertScoreQuery->bind_param('iii', $playerId, $worldId, $score);
		
		try {
			$insertScoreQuery->execute();			
		} catch (Exception $e) {
			echo "3: Creating player score failed. Message: " . $e->getMessage() . "\n";
			$insertScoreQuery->close();
			exit();
		} finally {
			$insertScoreQuery->close();
		}
	}

	function upsertScore($con, $playerId, $worldId, $score) {
		$scoreQuery = $con->prepare("SELECT player_id, world_id, score FROM points WHERE player_id = ? AND world_id = ?");
		$scoreQuery->bind_param('ss', $playerId, $worldId);
		$scoreQuery->execute();
		
		$result = $scoreQuery->get_result();
		$scoreQuery->close();
		
		if(mysqli_num_rows($result) == 1 and $score > $result->fetch_assoc()['score']) {
			updateScore($con, $playerId, $worldId, $score);
		} elseif(mysqli_num_rows($result) == 0 and $score > 0) {
			insertScore($con, $playerId, $worldId, $score);
		}
	}

	function main() {
		require_once "connect.php";
		$con = mysqli_connect($host, $dbUser, $dbPassword, $dbName, $dbPort);
		
		if(mysqli_connect_errno())
		{
			echo "1: Connection failed";
			exit();
		}
		
		$playerId = $_POST["playerId"];
		$worldId = $_POST["worldId"];
		$score = $_POST["score"];
		
		upsertScore($con, $playerId, $worldId, $score);
		
		echo "0";
		$con->close();
	}
	
	main();
?>