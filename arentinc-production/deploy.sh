#!/usr/bin/env sh

set -e

npm run build

cd dist

git init
git add -A
git commit -m "New Deplyment"
git push -f git@github.com:potatoscript/arentinc-production.git master:gh-pages

cd -