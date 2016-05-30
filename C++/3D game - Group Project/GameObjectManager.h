#pragma once
#ifndef GAME_OBJECT_MANAGER
#define GAME_OBJECT_MANAGER

#include <map>
#include <string>
using std::map;
using std::string;

class GameObject;
class Player;

class GameObjectManager
{
protected:
	map<string, GameObject*> allObjects;
	map<string, GameObject*> visibleObjects;
	map<string, GameObject*> collidingObjects;

	Player* player;

public:
	GameObjectManager();

	virtual ~GameObjectManager();

	void setPlayer(Player* player) { this->player = player; }

	Player* getPlayer() { return this->player; }

	void addObject(const string& name, GameObject* object);

	void updateVisibleObjects();

	map<string, GameObject*> &getVisibleObjects() { 
		return this->visibleObjects;
	}

	map<string, GameObject*> &getAllObjects() {
		return this->allObjects;
	}

	map<string, GameObject*> &getCollidingObjects() {
		return this->collidingObjects;
	}

	GameObject* getObject(const string& name);

	virtual void update(float elapsedSeconds);

	virtual void renderVisibleObjects();

	virtual void clearCollisions();

	virtual void checkForCollisions();

	virtual void resolveCollisions();
};

#endif

