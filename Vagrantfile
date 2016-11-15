# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant::Config.run do |config|
  config.vm.box = "ubuntu/trusty64"

  config.vm.box_url = "ubuntu/trusty64"
  config.vm.provision :shell, :inline => "sudo apt-get update"
  config.vm.provision :shell, :inline => "sudo apt-get install curl -y"
  config.vm.provision :shell, :inline => "sudo apt-get install vim -y"

  config.vm.provision :shell, :inline => "curl -sSL https://get.docker.com/gpg | sudo apt-key add -"
  config.vm.provision :shell, :inline => "curl -sSL https://get.docker.com/ | sh"
  config.vm.provision :shell, :inline => "curl -L https://github.com/docker/compose/releases/download/1.6.2/docker-compose-`uname -s`-`uname -m` > /usr/local/bin/docker-compose > docker-compose; chmod +x docker-compose; sudo mv docker-compose /usr/local/bin/docker-compose"
  config.vm.provision :shell, :inline => "sudo usermod -aG docker vagrant"
  config.vm.provision :shell, :inline => "git clone https://github.com/andmos/dotfiles"
  config.vm.provision :shell, :inline => "cp dotfiles/.bash_profile /home/vagrant; cp dotfiles/.vimrc /home/vagrant"
  config.vm.provision :shell, :inline => "echo All done, go vagrant ssh!"

  
end

Vagrant.configure("2") do |config|

config.vm.provider :virtualbox do |virtualbox|

virtualbox.customize ["modifyvm", :id, "--memory", "1024"]

end
end
