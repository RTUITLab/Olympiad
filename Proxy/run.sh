#!/bin/sh

set -e

if [ -z $BASIC_AUTH_USERNAME_ADMIN ]; then
  echo >&2 "BASIC_AUTH_USERNAME_ADMIN must be set"
  exit 1
fi

if [ -z $BASIC_AUTH_PASSWORD_ADMIN ]; then
  echo >&2 "BASIC_AUTH_PASSWORD_ADMIN must be set"
  exit 1
fi

htpasswd -bBc /etc/nginx/admin.htpasswd $BASIC_AUTH_USERNAME_ADMIN $BASIC_AUTH_PASSWORD_ADMIN


if [ -z $BASIC_AUTH_USERNAME_RESULTS_VIEWER ]; then
  echo >&2 "BASIC_AUTH_USERNAME_ADMIN must be set"
  exit 1
fi

if [ -z $BASIC_AUTH_PASSWORD_RESULTS_VIEWER ]; then
  echo >&2 "BASIC_AUTH_PASSWORD_ADMIN must be set"
  exit 1
fi

htpasswd -bBc /etc/nginx/results-viewer.htpasswd $BASIC_AUTH_USERNAME_RESULTS_VIEWER $BASIC_AUTH_PASSWORD_RESULTS_VIEWER


exec nginx -g "daemon off;"