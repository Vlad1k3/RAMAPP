#include <iostream>
#include <string>
#include <cstdlib> // Для функции std::system

using namespace std;

int main() {
    string program_exec;
    string name_group;
    string count_MB;

    getline(cin, program_exec);
    getline(cin, name_group);
    getline(cin, count_MB);

    // Формирование команд и их выполнение
    string create_group_command = "sudo cgcreate -g cpu,memory:" + name_group + " && sudo cgset -r memory.max=" + count_MB + "M " + name_group;
    cout << "Creating and setting up group command: " << create_group_command << endl;
    system(create_group_command.c_str());

    string set_owner_command = "sudo chown ssofixd /sys/fs/cgroup/" + name_group + "/cgroup.procs";
    cout << "Setting group owner command: " << set_owner_command << endl;
    system(set_owner_command.c_str());

    string exec_command = "cgexec -g cpu,memory:" + name_group + " " + program_exec;
    cout << "Executing program command: " << exec_command << endl;
    system(exec_command.c_str());
    
    return 0;
}
