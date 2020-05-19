#!/bin/bash

APP="Dock.Apps.InfoApi"
IMAGE="${APP,,}"
CONTAINER="$IMAGE.app"
PORT="8080"

../_helpers/docker.sh $APP $IMAGE $CONTAINER $PORT