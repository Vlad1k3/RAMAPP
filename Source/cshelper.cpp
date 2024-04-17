
#include <iostream>
#include <string>
#include <format>
#include <cctype> // Для использования функций isdigit и isalpha

using namespace std;

int main() {
    string program_exec;
    string name_group;
    string count_MB;

    // Ввод данных от пользователя
   
    getline(cin, program_exec);
   
    getline(cin, name_group);

    getline(cin, count_MB);


    string create_group_combined;
    string setup_combined;
    const string first_group_owner = " /sys/fs/cgroup";
    const string second_group_owner = "/cgroup.subtree_control /sys/fs/cgroup";
    string combined_exec;

    const char* command = nullptr;

    // create group
    create_group_combined ="sudo cgcreate -g cpu,memory:" + name_group + " && " + "sudo cgset -r memory.max=" + ""+ count_MB +"M " + name_group;
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);

    //owner group
    create_group_combined = "sudo chown ssofixd" + first_group_owner + "/" + name_group + second_group_owner + "/" + name_group + "/cgroup.procs" + first_group_owner + second_group_owner + "/cgroup.procs";
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);

    combined_exec = "cgexec -g cpu,memory:" + name_group + " " + program_exec;
    command = combined_exec.c_str();
    cout << command << endl;
    system(command);
    
    return 0;
}