#include "GameEngine.h"
#include "Logger.h"
#include "OGLShaderManager.h"
#include "GameWindow.h"
#include "GraphicsSystem.h"
#include "CoreSystem.h"
#include "PCInputSystem.h"
#include "GameWorld.h"
#include "ITimer.h"
#include "GameObjectManager.h"
#include "BackForthBehavior.h"
#include "OGLObject.h"
#include "OGLReferenceFrame.h"
#include "FourPointBehavior.h"
#include "Patrol.h"
#include "FourPointPatrol.h"
#include "windTurbineBehavior.h"
#include "JumpBehavior.h"
GameEngine::GameEngine(
	Logger *logger,
	CoreSystem *core, 
	GraphicsSystem *graphics, 
	GameWindow *window,
	PCInputSystem *inputSystem,
	ITimer *timer)
{
	this->logger = logger;

	this->core = core;
	this->core->setLogger(this->logger);

	this->graphics = graphics;
	this->graphics->setLogger(this->logger);

	this->window = window;
	this->window->setLogger(this->logger);
	this->window->setGameEngine(this);

	this->inputSystem = inputSystem;
	this->graphics->getGameWorld()->setInputSystem(this->inputSystem);

	this->timer = timer;

	this->initialized = false;
}

GameEngine::~GameEngine()
{
	delete this->logger;
	delete this->core;
	delete this->graphics;
	delete this->window;
	delete this->inputSystem;
	delete this->timer;
}

void GameEngine::initializeWindowAndGraphics()
{
	// First create the window
	this->initialized = this->window->create();
	if (this->initialized) {
		// Next, intialize the graphics system
		this->initialized = this->graphics->initialize();
	}
}

void GameEngine::setupGame()
{
	//Wind turbine object
	OGLObject* object = (OGLObject*)
		this->graphics->getGameWorld()->getObjectManager()->getObject("windTurbine");
	object->referenceFrame.rotateX(-90.0f);
	object->referenceFrame.rotateZ(-90.0f);
	//appying windTurbine behavior
	object->setBehavior(new windTurbineBehavior(10));
	
	//Rotating the object "Fan" on z-axis 90 degrees
	object = (OGLObject*)
		this->graphics->getGameWorld()->getObjectManager()->getObject("Fan");
	object->referenceFrame.rotateZ(90.0f);


	//Character object
	for (int i = 1; i <= 8; i++) {
		string name = "Character" + std::to_string(i);
		object = (OGLObject*)
			this->graphics->getGameWorld()->getObjectManager()->getObject(name);
	//appying jump behavior
	object->setBehavior(new JumpBehavior(10));
	}
	

	//Character object
	for (int i = 1; i <= 4; i++) {
		string name = "Car" + std::to_string(i);
		object = (OGLObject*)
			this->graphics->getGameWorld()->getObjectManager()->getObject(name);
	//appying four point patrol behavior
	object->setBehavior(new FourPointPatrol(12));
	}
}

void GameEngine::run()
{
	if (this->initialized){
		this->window->show();
		this->window->listenForEvents(this->timer);
	}
	else {
		if (this->logger) {
			this->logger->log("The engine was not initialized!");
		}
	}
}


