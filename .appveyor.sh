pwd && ls -la
which ruby && ruby --version
rvm use 2.4.1 && which ruby && ruby --version
rvm use 2.4.1 && ruby src/docs-docker.rb -c dev 
rvm use 2.4.1 && ruby src/docs-checkout.rb -c dev 
rvm use 2.4.1 && ruby src/docs-build.rb -c dev 
rvm use 2.4.1 && ruby src/docs-publish.rb -c dev 