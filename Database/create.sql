CREATE TABLE GAME_USER (
    id INT NOT NULL AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(50) NOT NULL UNIQUE,
    PRIMARY KEY (id)
);

CREATE TABLE USER_POINTS (
    user_id INT NOT NULL,
    world_id INT NOT NULL,
    points INT NOT NULL,
	UNIQUE (user_id, world_id),
    FOREIGN KEY (user_id) REFERENCES GAME_USER(id)
);