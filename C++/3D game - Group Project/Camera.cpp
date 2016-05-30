#include "Camera.h"
#include "Player.h"

Camera::Camera() : GameObject("Camera")
{
	this->player = nullptr;
}

Camera::~Camera()
{
}

void Camera::setTarget(float x, float y, float z)
{
	this->target = glm::vec3(x, y, z);
	this->updateOrientation();
}

void Camera::setUp(float x, float y, float z)
{
	this->up = glm::vec3(x, y, z);
	this->updateOrientation();
}

void Camera::updateOrientation()
{
}

void Camera::setPlayer(Player* player)
{
	this->player = player;
}