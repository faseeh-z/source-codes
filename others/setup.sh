#!/bin/bash

# Update package list
sudo apt update -y

# Install g++ and libsfml-dev
sudo apt install -y g++ libsfml-dev

# Install dependencies for Sublime Text
sudo apt install -y apt-transport-https ca-certificates curl software-properties-common

# Import the Sublime Text GPG key
curl -fsSL https://download.sublimetext.com/sublimehq-pub.gpg | sudo gpg --dearmor -o /usr/share/keyrings/sublime-archive-keyring.gpg

# Add the Sublime Text repository
echo "deb [signed-by=/usr/share/keyrings/sublime-archive-keyring.gpg] https://download.sublimetext.com/ apt/stable/" | sudo tee /etc/apt/sources.list.d/sublime-text.list

# Update apt package list again after adding the Sublime Text repository
sudo apt update -y

# Install Sublime Text
sudo apt install -y sublime-text

