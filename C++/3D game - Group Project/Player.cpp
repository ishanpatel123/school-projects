#include "Player.h"
#include "Camera.h"

Player::Player(const string& name) : GameObject(name)
{
	this->camera = nullptr;
}

Player::~Player()
{
}

void Player::update(float elapsedSeconds)
{
}

void Player::render()
{
}

void Player::setCamera(Camera* camera)
{
	this->camera = camera;
}
