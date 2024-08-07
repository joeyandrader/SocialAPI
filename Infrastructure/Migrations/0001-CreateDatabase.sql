CREATE TABLE Persons (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Bio TEXT,
    ProfilePictureUrl VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Posts (
    Id SERIAL PRIMARY KEY,
    PersonId INT REFERENCES Persons(Id),
    Title VARCHAR(255) NOT NULL,
    Content TEXT NOT NULL,
    ImageUrl VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Comments (
    Id SERIAL PRIMARY KEY,
    PostId INT REFERENCES Posts(Id),
    PersonId INT REFERENCES Persons(Id),
    Content TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Tags (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE PostTags (
    PostId INT REFERENCES Posts(Id),
    TagId INT REFERENCES Tags(Id),
    PRIMARY KEY (PostId, TagId)
);

CREATE TABLE Followers (
    FollowerId INT REFERENCES Persons(Id),
    FollowedId INT REFERENCES Persons(Id),
    PRIMARY KEY (FollowerId, FollowedId),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Images (
    Id SERIAL PRIMARY KEY,
    PostId INT REFERENCES Posts(Id),
    Url VARCHAR(255) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);

CREATE TABLE Videos (
    Id SERIAL PRIMARY KEY,
    PostId INT REFERENCES Posts(Id),
    Url VARCHAR(255) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP 
);