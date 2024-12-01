#!/bin/bash

# Update system and install Git
echo "Updating system and installing Git..."
sudo apt update && sudo apt install -y git

# Check Git installation
git --version
if [ $? -ne 0 ]; then
    echo "Git installation failed."
    exit 1
fi
echo "Git installed successfully."

# Install Git LFS
echo "Installing Git LFS..."
curl -s https://packagecloud.io/install/repositories/github/git-lfs/script.deb.sh | sudo bash
sudo apt-get install -y git-lfs

# Check Git LFS installation
git lfs --version
if [ $? -ne 0 ]; then
    echo "Git LFS installation failed."
    exit 1
fi
echo "Git LFS installed successfully."

# Initialize Git LFS
echo "Initializing Git LFS..."
git lfs install

# Configure Git (replace with your details)
read -p "Enter your Git username: " git_username
read -p "Enter your Git email: " git_email
git config --global user.name "$git_username"
git config --global user.email "$git_email"
echo "Git configured with username: $git_username and email: $git_email."

# Generate SSH key
echo "Generating SSH key..."
ssh-keygen -t rsa -b 4096 -C "$git_email" -f ~/.ssh/id_rsa -N ""
if [ $? -ne 0 ]; then
    echo "SSH key generation failed."
    exit 1
fi
echo "SSH key generated successfully."

# Start the SSH agent and add the key
echo "Adding SSH key to SSH agent..."
eval "$(ssh-agent -s)"
ssh-add ~/.ssh/id_rsa

# Display the public key
echo "Copy the following SSH key and add it to your Git hosting service (GitHub/GitLab):"
cat ~/.ssh/id_rsa.pub

# Test SSH connection
read -p "Enter the Git hosting service (e.g., github.com): " git_host
echo "Testing SSH connection to $git_host..."
ssh -T git@$git_host

if [ $? -eq 1 ]; then
    echo "SSH key added successfully and tested."
else
    echo "Error: Unable to connect to $git_host. Verify the SSH key is added to your account."
fi
