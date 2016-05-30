#include <Windows.h>
#include "TheGame.h"
#include "OGLShaderManager.h"
#include "GameEngine.h"
#include "OGLShaderManager.h"
#include "OGLGraphicsSystem.h"
#include "OGLViewingFrustum.h"
#include "GameWorld.h"
#include "LightSource.h"
#include "Camera.h"
#include "CoreSystem.h"
#include "OGLVertexShader.h"
#include "TextFileReader.h"
#include "OGLFragmentShader.h"
#include "AssetLoader.h"
#include "OGLFirstPersonCamera.h"
#include "OGLObject.h"
#include "RotateYBehavior.h"
#include "GameObjectManager.h"
#include "PCInputSystem.h"
#include "BackForthBehavior.h"
#include "OGL3DObject.h"
#include "OGL2DTextDisplay.h"
#include "BMPTextureLoader.h"
#include "OGL2DTexture.h"
#include "Plane.h"
#include "CustomTexture.h"
#include "TexturedCuboid.h"
#include "TextureManager.h"
#include "GameAssetLoader.h"
#include "LineBox.h"
#include "Sphere.h"
#include "Pyramid.h"
#include "OGLTexturedFlatSurface.h"
#include "Construct.h"
#include "Axis.h"
#include "Logger.h"
#include "Player.h"
#include "Door.h"
#include "Ghost1.h"
#include "Ghost2.h"
#include "GhostObject.h"
#include "Key.h"
#include <gl\glew.h>
#include <glm\gtc\type_ptr.hpp>
#include <sstream>
#include <fstream>
#include <string>
#include <array>
#include <vector>
#include <algorithm>

using namespace std;
TheGame::TheGame() : BaseObject(nullptr)
{
}

TheGame::~TheGame()
{
}

void TheGame::loadShaders(const string& shaderAssetFilename)
{
	GameAssetLoader* loader = (GameAssetLoader*)this->gameEngine->getAssetLoader();
	loader->loadAssetFile(shaderAssetFilename);
	loader->loadOnlyTheShaders();
}

void TheGame::setupGraphicsParameters(const string& uniformAssetFilename)
{
	GameAssetLoader* loader = (GameAssetLoader*)this->gameEngine->getAssetLoader();
	loader->loadAssetFile(uniformAssetFilename);
	loader->loadOnlyTheUniforms();
}

void TheGame::setupViewingEnvironment()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLViewingFrustum* frustum = (OGLViewingFrustum*)graphics->getViewingFrustum();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	OGLShaderProgram* shader = 
		(OGLShaderProgram*)shaderMgr->getShader("ShaderProgramIllumination");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	// Cull back faces and use counter-clockwise winding of front faces
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);
	glFrontFace(GL_CCW);

	// Enable depth testing
	glEnable(GL_DEPTH_TEST);
	glDepthMask(GL_TRUE);
	glDepthFunc(GL_LEQUAL);
	glDepthRange(0.0f, 1.0f);
}

void TheGame::sendShaderData()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLViewingFrustum* frustum = (OGLViewingFrustum*)graphics->getViewingFrustum();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	OGLShaderProgram* shader =
		(OGLShaderProgram*)shaderMgr->getShader("ShaderProgramIllumination");

	glm::vec3 globalLightPos = glm::vec3(100, 100, 0);
	shader->setUniformData(
		"worldGlobalLightPos",
		(void*)glm::value_ptr(globalLightPos));
	shader->sendData("worldGlobalLightPos");

	float globalLightIntensity = 0.0f;
	shader->setUniformData(
		"globalLightIntensity",
		(void*)&globalLightIntensity);
	shader->sendData("globalLightIntensity");

	GameWorld* gameWorld = graphics->getGameWorld();

	int numberOfLights = (int)gameWorld->localLights.size();
	shader->setUniformData(
		"numberOfLights",
		(void*)&numberOfLights);
	shader->sendData("numberOfLights");

	glm::vec3 lightPositions[10];
	float lightIntensities[10];
	for (int i = 0; i < numberOfLights; i++) {
		lightPositions[i] = gameWorld->localLights[i]->getPosition();
		lightIntensities[i] = gameWorld->localLights[i]->getIntensity();
	}
	shader->setUniformData(
		"lightPositions",
		(void*)lightPositions);
	shader->sendData("lightPositions");

	shader->setUniformData(
		"lightIntensities",
		(void*)lightIntensities);
	shader->sendData("lightIntensities");

	Camera *camera = (Camera*)gameWorld->getCamera();

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->referenceFrame.orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->referenceFrame.orientation[3])));
	shader->sendData("worldCameraPos");

	// Texture Shader
	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");

	shader->setUniformData(
		"worldGlobalLightPos",
		(void*)glm::value_ptr(globalLightPos));
	shader->sendData("worldGlobalLightPos");

	shader->setUniformData(
		"globalLightIntensity",
		(void*)&globalLightIntensity);
	shader->sendData("globalLightIntensity");

	shader->setUniformData(
		"numberOfLights",
		(void*)&numberOfLights);
	shader->sendData("numberOfLights");

	shader->setUniformData(
		"lightPositions",
		(void*)lightPositions);
	shader->sendData("lightPositions");

	shader->setUniformData(
		"lightIntensities",
		(void*)lightIntensities);
	shader->sendData("lightIntensities");

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->referenceFrame.orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->referenceFrame.orientation[3])));
	shader->sendData("worldCameraPos");

	shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->referenceFrame.orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->referenceFrame.orientation[3])));
	shader->sendData("worldCameraPos");
}

// Called last in GraphicsSystem::update()
void TheGame::update(float elapsedSeconds)
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	GameObjectManager* objectMgr = graphics->getGameWorld()->getObjectManager();
	OGLFirstPersonCamera *camera =
		(OGLFirstPersonCamera *)graphics->getGameWorld()->getCamera();
	Player* player = objectMgr->getPlayer();

	glm::vec3 position = camera->getPosition();
	position.y -= 2.5f;
	player->setPosition(position);
	player->updateBoundingBox();
}

void TheGame::Objects(int type, const string & name, float width, float depth, float height, float x, float y, float z, float rotateY, float red, float green, float blue, float alpha)
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	TextureManager* texMgr = graphics->getTextureManager();
	GameObjectManager* objectMgr = graphics->getGameWorld()->getObjectManager();

	OGLShaderProgram* shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	OGL2DTexture* texture = (OGL2DTexture*)texMgr->getTexture("PlainTex");
	OGLObject* object;
	if (type == 1)
	{
		object = new TexturedCuboid(name, width, depth, height, { red, green, blue, alpha });

		object->referenceFrame.setPosition(x, y, z);

		if (rotateY != 0) {
			object->referenceFrame.rotateY(rotateY);
		}

		object->setTexture(texture);
		object->setShaderProgram(shader->getHandle());
		objectMgr->addObject(object->getName(), object);
		object->setVisibility(true);
		object = (OGL3DObject*)graphics->getGameObject(name);
		if (object) {
			TexturedCuboid* p = (TexturedCuboid*)object;
			object->boundingBox.set(p->getWidth(), p->getDepth(), p->getHeight());
			object->boundingBox.use = true;
			object->setVisibility(true);

		}
	}
	else if (type == 2)
	{
		object = new Ghost1(name, texture);
		object->referenceFrame.setPosition(x, y, z);
		object->setTexture(texture);
		object->setShaderProgram(shader->getHandle());
		objectMgr->addObject(object->getName(), object);
		object->setVisibility(true);
		object = (OGL3DObject*)graphics->getGameObject(name);
		if (object) {
			GhostObject* p = (GhostObject*)object;

			object->boundingBox.set(p->getWidth() + 2, p->getDepth() - 0.7f, p->getHeight() + 3);
			object->boundingBox.use = true;
			object->setVisibility(true);
		}
	}
	else if (type == 3)
	{
		object = new Ghost2(name, texture);
		object->referenceFrame.setPosition(x, y, z);
		object->setTexture(texture);
		object->setShaderProgram(shader->getHandle());
		objectMgr->addObject(object->getName(), object);
		object->setVisibility(true);
		object = (OGL3DObject*)graphics->getGameObject(name);
		if (object) {
			GhostObject* p = (GhostObject*)object;

			object->boundingBox.set(p->getWidth() + 2, p->getDepth() - 0.7f, p->getHeight() + 3);
			object->boundingBox.use = true;
			object->setVisibility(true);
		}
	}
}
void TheGame::setup(const string& gameAssetFilename)
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	TextureManager* texMgr = graphics->getTextureManager();
	GameObjectManager* objectMgr = graphics->getGameWorld()->getObjectManager();

	OGLShaderProgram* plainShader3d = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");
	OGLShaderProgram* textShader = (OGLShaderProgram*)shaderMgr->getShader("TextShader");

	AssetLoader* loader = this->gameEngine->getAssetLoader();
	this->logger->log("Loading assets...");
	loader->loadAssetFile(gameAssetFilename);
	loader->loadAssets();
	this->logger->log("...Done loading assets.");

	OGLFirstPersonCamera *camera =
		(OGLFirstPersonCamera *)graphics->getGameWorld()->getCamera();
	//camera->setPosition(-96.0f, 5.0f, 48.0f);
	camera->setPosition(9.0f, 4.0f, 11.5f);

	Player* player = objectMgr->getPlayer();
	player->boundingBox.set(2, 2, 5);
	player->boundingBox.use = true;
	player->setFixedInPlace(false);

	camera->setPlayer(player);
	player->setCamera(camera);

	player->referenceFrame = camera->referenceFrame;
	player->updateBoundingBox();

	LightSource *light = new LightSource();
	light->setPosition(0.0f, 10.5f, 0.0f);
	light->setIntensity(0.5f);
	graphics->getGameWorld()->localLights.push_back(light);

	OGL2DTexture* texture = (OGL2DTexture*)texMgr->getTexture("Letters");
	OGL2DTextDisplay* textDisplay = new OGL2DTextDisplay();
	textDisplay->setTexture(texture);
	textDisplay->setShaderProgram(textShader->getHandle());
	graphics->setTextDisplay(textDisplay);

	OGLObject* object = (OGLObject*)graphics->getGameObject("Axes");
	if (object) {
		object->setVisibility(true);
	}

	object = (OGLObject*)graphics->getGameObject("Floor");
	if (object) {
		object->setVisibility(true);
	}
	
	OGLShaderProgram* shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgramIllumination");
	OGLObject* key = new Key("key1");
	key->setBehavior(new RotateYBehavior(key, 45));
	key->referenceFrame.setPosition(24, 3, 3);
	key->referenceFrame.scale(0.2f);
	key->boundingBox.set(8, 1, 4);
	key->boundingBox.use = true;
	key->boundingBox.applyTransform();
	key->setShaderProgram(shader->getHandle());
	objectMgr->addObject(key->getName(), key);
	key->setVisibility(true);
	ReadData();
	int i = 0;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha); 	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);	i++;
	Objects(data[i].type, data[i].name, data[i].width, data[i].depth, data[i].height, data[i].x, data[i].y, data[i].z, data[i].rotateY, data[i].red, data[i].green, data[i].blue, data[i].alpha);

	objectMgr->update(0);
}

void TheGame::updateTextDisplay()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGL2DTextDisplay* textDisplay = graphics->getTextDisplay();

	textDisplay->clear();
	textDisplay->addText("Find All Treasure!", -1, 1);
	auto collidingObjs = 
		graphics->getGameWorld()->getObjectManager()->getCollidingObjects();

	string colliding = "";
	OGL3DObject *object;
	//auto iterator = collidingObjs.begin();
	//while (iterator != collidingObjs.end()) {
	//	object = (OGL3DObject*)iterator->second;
	//	colliding += object->getName();
	//	iterator++;
	//}
	//textDisplay->addText(colliding, -1.0f, 0);

	GameObjectManager* objectMgr = graphics->getGameWorld()->getObjectManager();
	Player* player = objectMgr->getPlayer();

	std::stringstream ss;
	ss << player->getPosition().x << ", " << player->getPosition().y << " " << player->getPosition().z;
	colliding = "Player: " + ss.str() + " ";
	auto playerColliding = player->getObjectsColliding();
	auto it = playerColliding.begin();
	while (it != playerColliding.end()) {
		object = (OGL3DObject*)it->second;
		colliding += object->getName();
		it++;
	}
	textDisplay->addText(colliding, -1.0f, -0.1f);
}

void TheGame::processInputs()
{
	OGLGraphicsSystem* graphics = 
		(OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLFirstPersonCamera *camera = 
		(OGLFirstPersonCamera *)graphics->getGameWorld()->getCamera();
	PCInputSystem* inputSystem = this->gameEngine->getInputSystem();

	camera->setJustLooking();
	camera->setNotMoving();

	if (inputSystem->keys[VK_LEFT]) {
		camera->setLookingLeft();
	}
	else if (inputSystem->keys[VK_RIGHT]) {
		camera->setLookingRight();
	}

	if (inputSystem->keys[VK_UP]) {
		camera->setLookingUp();
	}
	else if (inputSystem->keys[VK_DOWN]) {
		camera->setLookingDown();
	}

	if (inputSystem->keys['W']) {
		camera->setMovingForward();
	}
	else if (inputSystem->keys['S']) {
		camera->setMovingBackward();
	}
	if (inputSystem->keys['A']) {
		camera->setMovingLeft();
	}
	else if (inputSystem->keys['D']) {
		camera->setMovingRight();
	}

	if (inputSystem->isMouseMovingLeft()) {
		camera->setLookingLeft();
	}
	else if (inputSystem->isMouseMovingRight()) {
		camera->setLookingRight();
	}

	if (inputSystem->isMouseMovingUp()) {
		camera->setLookingUp();
	}
	else if (inputSystem->isMouseMovingDown()) {
		camera->setLookingDown();
	}
}


void TheGame::ReadData()
{
	string line;
	int num = 0;
	ifstream fin;
	fin.open("Data.txt");
	int i = 0;
	while (!fin.eof())
	{
		getline(fin, line);
		if (fin.fail())
		{
			break;
		}
		if (line.find("//") != -1) {
			num++;
			i = 0;
		}
		else {
			stringstream   linestream(line);
			if (num == 1)
			{
				linestream >> data[i].type >> data[i].name >> data[i].width >> data[i].depth >> data[i].height >> data[i].x >> data[i].y >> data[i].z >> data[i].rotateY >> data[i].red >> data[i].green >> data[i].blue >> data[i].alpha;
				i++;
			}
		}
	}
	fin.close();
}
