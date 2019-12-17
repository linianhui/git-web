# Git internal object web explore api
base on https://github.com/libgit2/libgit2sharp

# CI

| CI Service     | Platform | Test Status                                 |
| -------------- | -------- | ------------------------------------------- |
| GitHub Actions | docker   | [![GitHub-Actions-Img]][GitHub-Actions-Url] |

# Run

http://localhost:9001

## docker-compose.yml (docker platform)
```bash
## start docker
docker-compose up --detach --build

## stop docker
docker-compose down
```

# Docker image

https://hub.docker.com/r/lnhcode/git.web

# Reference
https://git-scm.com/book/en/v2/Git-Internals-Plumbing-and-Porcelain



[GitHub-Actions-Img]:https://github.com/linianhui/git.web/workflows/test/badge.svg
[GitHub-Actions-Url]:https://github.com/linianhui/git.web/actions
