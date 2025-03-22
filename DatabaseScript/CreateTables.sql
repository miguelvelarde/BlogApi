
--2025-03-22 12:28:54.9912
CREATE TABLE Posts (
    Id INT AUTO_INCREMENT PRIMARY KEY,  -- Columna para la clave primaria y auto-incremental
    Title VARCHAR(255) NOT NULL,        -- Columna para el título con un máximo de 255 caracteres
    Content TEXT NOT NULL,              -- Columna para el contenido con un tipo TEXT (para 5000 caracteres)
    ImagePath VARCHAR(255),             -- Columna opcional para la ruta de la imagen
    Tags VARCHAR(100) NOT NULL,         -- Columna para los tags con un máximo de 100 caracteres
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, -- Columna para la fecha de creación, valor por defecto: fecha y hora actual
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP -- Columna para la fecha de actualización, se actualiza automáticamente
);


--2025-03-22 12:29:27.4514
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,          -- Columna para la clave primaria y auto-incremental
    UserName VARCHAR(255) NOT NULL,              -- Columna para el nombre de usuario con un máximo de 255 caracteres
    NickName VARCHAR(255),                       -- Columna para el apodo con un máximo de 255 caracteres, puede ser NULL
    Password VARCHAR(255) NOT NULL               -- Columna para la contraseña con un máximo de 255 caracteres
);
