#!/bin/bash

APP="Dock.Apps.UserApi"
IMAGE="${APP,,}"
CONTAINER="$IMAGE.app"
PORT="16000"

../_helpers/docker.sh $APP $IMAGE $CONTAINER $PORT