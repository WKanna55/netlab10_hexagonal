
-- Tabla Roles
CREATE TABLE roles (
    role_id UUID PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla Usuarios
CREATE TABLE users (
    user_id UUID PRIMARY KEY,
    username VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    email VARCHAR(150) UNIQUE,
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
);

-- Tabla pivote para asignar roles a usuarios (muchos a muchos)
CREATE TABLE user_roles (
    user_id UUID NOT NULL,
    role_id UUID NOT NULL,
    assigned_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (role_id) REFERENCES roles(role_id) ON DELETE CASCADE
);

-- Tabla Tickets
CREATE TABLE tickets (
    ticket_id UUID PRIMARY KEY,
    user_id UUID NOT NULL,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    status VARCHAR(20) NOT NULL CHECK (status IN ('abierto', 'en_proceso', 'cerrado')),
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    closed_at TIMESTAMP WITHOUT TIME ZONE NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Tabla Respuestas
CREATE TABLE responses (
    response_id UUID PRIMARY KEY,
    ticket_id UUID NOT NULL,
    responder_id UUID NOT NULL,
    message TEXT NOT NULL,
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    FOREIGN KEY (ticket_id) REFERENCES tickets(ticket_id) ON DELETE CASCADE,
    FOREIGN KEY (responder_id) REFERENCES users(user_id)
);