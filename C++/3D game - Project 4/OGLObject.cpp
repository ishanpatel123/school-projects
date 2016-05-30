#include "OGLObject.h"
#include "OGL2DTexture.h"

#include <glm\gtc\type_ptr.hpp>

#ifndef NULL
#define NULL 0
#endif

OGLObject::OGLObject(string name) : OGLGameObject(name)
{
	this->vao = 0;
	this->setArrayBufferType();
}

OGLObject::~OGLObject()
{
	for (auto iterator = this->objects.begin(); iterator != this->objects.end(); iterator++) {
		delete iterator->second;
	}
	glDeleteVertexArrays(1, &this->vao);
}

void OGLObject::addVBOObject(VBOObject * object)
{
	if (this->vao == 0) {
		glGenVertexArrays(1, &this->vao);
	}
	glBindVertexArray(this->vao);
	object->vbo = createBufferObject(
		GL_ARRAY_BUFFER, 
		object->buffer, 
		object->bufferSizeInBytes);
	if (this->vboType == INDEXED_ARRAY) {
		object->ibo = createBufferObject(
			GL_ELEMENT_ARRAY_BUFFER, 
			object->indexData, 
			object->indexSizeInBytes);
	}
	
	this->objects[object->name] = object;
	glBindVertexArray(0);
}

void OGLObject::update(float elapsedSeconds)
{
	GameObject::update(elapsedSeconds);
}

VBOObject * OGLObject::createVBOObject(string name, float* vertexData, GLenum primitiveType)
{
	VBOObject * object = new VBOObject();
	object->name = name;
	object->vbo = 0;
	object->primitiveType = primitiveType;
	object->buffer = &vertexData[1];
	object->bufferSizeInBytes = (unsigned int)vertexData[0] * sizeof(float);
	object->numberOfVertices = (unsigned int)vertexData[0] / sizeof(float) / 2;
	object->indexData = NULL;
	object->indexSizeInBytes = 0;
	object->numberOfIndexes = 0;
	object->positionComponent.type = GL_FLOAT;
	object->positionComponent.count = 4;
	object->positionComponent.bytesToFirst = 0;
	object->positionComponent.bytesToNext = object->positionComponent.count * sizeof(float);
	object->colorComponent.type = GL_FLOAT;
	object->colorComponent.count = 4;
	object->colorComponent.bytesToFirst = 
		sizeof(float) * object->numberOfVertices * object->positionComponent.count;
	object->colorComponent.bytesToNext = object->colorComponent.count * sizeof(float);
	return object;
}

VBOObject* OGLObject::createVBOObject(
	string name, float* vertexData, short* indexData, GLenum primitiveType)
{
	VBOObject * object = new VBOObject();
	object->positionComponent.count = 4;
	object->colorComponent.count = 4;
	object->normalComponent.count = 3;
	object->numberOfVertices = (unsigned int)vertexData[0] /
		(object->positionComponent.count 
			+ object->colorComponent.count + object->normalComponent.count);

	object->name = name;
	object->vbo = 0;
	object->primitiveType = primitiveType;
	object->buffer = &vertexData[1];
	object->bufferSizeInBytes = (unsigned int)vertexData[0] * sizeof(float);
	
	object->indexData = &indexData[1];
	object->numberOfIndexes = indexData[0];
	object->indexSizeInBytes = object->numberOfIndexes * sizeof(short);
	// Positions
	object->positionComponent.type = GL_FLOAT;
	object->positionComponent.bytesToFirst = 0;
	object->positionComponent.bytesToNext = 0;
	// Colors
	object->colorComponent.type = GL_FLOAT;
	object->colorComponent.bytesToFirst = 
		sizeof(float) * object->positionComponent.count * object->numberOfVertices;
	object->colorComponent.bytesToNext = 0;
	// Normals
	object->normalComponent.type = GL_FLOAT;
	object->normalComponent.bytesToFirst =
		sizeof(float) * (object->positionComponent.count + object->colorComponent.count) * object->numberOfVertices;
	object->normalComponent.bytesToNext = 0;
	return object;
}

VBOObject* OGLObject::createTextureVBOObject(
	string name, float* vertexData, short* indexData, GLenum primitiveType)
{
	VBOObject * object = new VBOObject();
	object->positionComponent.count = 4;
	object->colorComponent.count = 4;
	object->normalComponent.count = 3;
	object->textureComponent.count = 2;
	object->numberOfVertices = (unsigned int)vertexData[0] /
		(object->positionComponent.count
			+ object->colorComponent.count 
			+ object->normalComponent.count
			+ object->textureComponent.count);

	object->name = name;
	object->vbo = 0;
	object->primitiveType = primitiveType;
	object->buffer = &vertexData[1];
	object->bufferSizeInBytes = (unsigned int)vertexData[0] * sizeof(float);

	object->indexData = &indexData[1];
	object->numberOfIndexes = indexData[0];
	object->indexSizeInBytes = object->numberOfIndexes * sizeof(short);
	// Positions
	object->positionComponent.type = GL_FLOAT;
	object->positionComponent.bytesToFirst = 0;
	object->positionComponent.bytesToNext = 0;
	// Colors
	object->colorComponent.type = GL_FLOAT;
	object->colorComponent.bytesToFirst =
		sizeof(float) * object->positionComponent.count * object->numberOfVertices;
	object->colorComponent.bytesToNext = 0;
	// Normals
	object->normalComponent.type = GL_FLOAT;
	object->normalComponent.bytesToFirst =
		sizeof(float) * (object->positionComponent.count + object->colorComponent.count) * object->numberOfVertices;
	object->normalComponent.bytesToNext = 0;
	// Texture coordinates
	object->textureComponent.type = GL_FLOAT;
	object->textureComponent.bytesToFirst =
		sizeof(float) 
		* (object->positionComponent.count 
			+ object->colorComponent.count 
			+ object->normalComponent.count)
		* object->numberOfVertices;
	object->normalComponent.bytesToNext = 0;
	return object;
}

VBOObject * OGLObject::getVBOObject(string name)
{
	if (this->objects.find(name) != this->objects.end()) {
		return this->objects[name];
	}
	return NULL;
}

GLuint OGLObject::createBufferObject(GLenum target, const void* bufferData, GLsizei bufferSize)
{
	GLuint bufferObjectID = 0;
	glGenBuffers(1, &bufferObjectID);
	this->targetBufferObject = target;
	this->updateBufferObject(bufferObjectID, bufferData, bufferSize);
	return bufferObjectID;
}

void OGLObject::updateBufferObject(GLuint bufferObjectID, const void* bufferData, GLsizei bufferSize)
{
	glBindBuffer(this->targetBufferObject, bufferObjectID);
	glBufferData(this->targetBufferObject, bufferSize, bufferData, GL_STATIC_DRAW);
	glBindBuffer(this->targetBufferObject, 0);
}

void OGLObject::renderVBOObjects()
{
	auto iterator = this->objects.begin();
	while (iterator != this->objects.end()) {
		this->renderObject(iterator->second);
		iterator++;
	}
}

void OGLObject::renderObject(VBOObject * object)
{
	glBindVertexArray(this->vao);
	glUseProgram(this->shaderProgram);
	glBindBuffer(GL_ARRAY_BUFFER, object->vbo);
	this->enablePositions(object);
	this->enableColors(object);
	this->enableNormals(object);
	if (this->isTextured()) {
		this->enableTextures(object);
	}
	this->drawObject(object);
	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);
	if (this->isTextured()) {
		glDisableVertexAttribArray(3);
		glBindTexture(GL_TEXTURE_2D, 0);
	}
	glUseProgram(0);
	glBindVertexArray(0);
}

void OGLObject::enablePositions(VBOObject * object)
{
	glEnableVertexAttribArray(0);
	glVertexAttribPointer(
		0,
		object->positionComponent.count,
		object->positionComponent.type,
		GL_FALSE,
		object->positionComponent.bytesToNext,
		(void*)object->positionComponent.bytesToFirst
	);
}

void OGLObject::enableColors(VBOObject * object)
{
	glEnableVertexAttribArray(1);
	glVertexAttribPointer(
		1,
		object->colorComponent.count,
		object->colorComponent.type,
		GL_FALSE,
		object->colorComponent.bytesToNext,
		(void*)object->colorComponent.bytesToFirst
	);
}

void OGLObject::enableNormals(VBOObject * object)
{
	glEnableVertexAttribArray(2);
	glVertexAttribPointer(
		2,
		object->normalComponent.count,
		object->normalComponent.type,
		GL_FALSE,
		object->normalComponent.bytesToNext,
		(void*)object->normalComponent.bytesToFirst
	);
}

void OGLObject::enableTextures(VBOObject * object)
{
	glEnableVertexAttribArray(3);
	glVertexAttribPointer(
		3,
		object->textureComponent.count,
		object->textureComponent.type,
		GL_FALSE,
		object->textureComponent.bytesToNext,
		(void*)object->textureComponent.bytesToFirst
	);
	OGL2DTexture *texture = (OGL2DTexture *)this->texture;
	this->texture->select();
}

void OGLObject::drawObject(VBOObject * object)
{
	if (this->vboType == INDEXED_ARRAY) {
		glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, object->ibo);
		glDrawElements(object->primitiveType, object->numberOfIndexes, GL_UNSIGNED_SHORT, 0);
	}
	else {
		glDrawArrays(object->primitiveType, 0, object->numberOfVertices);
	}
}

void OGLObject::sendMaterialDataToGPU()
{
	auto ambientLocation =
		glGetUniformLocation(
			this->shaderProgram, "materialAmbientIntensity");
	auto shininessLocation =
		glGetUniformLocation(
			this->shaderProgram, "materialShininess");
	auto specularLocation =
		glGetUniformLocation(
			this->shaderProgram, "materialSpecular");

	glUseProgram(this->shaderProgram);
	glUniform1f(ambientLocation, this->material.ambientIntensity);
	glUniform1f(shininessLocation, this->material.shininess);
	glm::vec4 vector =
		glm::vec4(
			this->material.specular.red,
			this->material.specular.green,
			this->material.specular.blue,
			this->material.specular.alpha);
	glUniform4fv(specularLocation, 1, glm::value_ptr(vector));
	glUseProgram(0);
}

