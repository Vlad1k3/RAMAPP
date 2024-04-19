
#include <iostream>
#include <string>
#include <format>
#include <cctype> 

using namespace std;

int main() {
    string program_exec;
    string name_group;
    string count_MB;

    // Ввод данных от пользователя
   
    getline(cin, program_exec);
   
    getline(cin, name_group);

    getline(cin, count_MB);




    const char* command = nullptr;

    // create group
    string create_group_combined ="sudo cgcreate -g cpu,memory:" + name_group + " && " + "sudo cgset -r memory.max=" + ""+ count_MB +"M " + name_group;
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);

    //owner group
    create_group_combined = "sudo chown ssofixd /sys/fs/cgroup/" + name_group + "/cgroup.subtree_control /sys/fs/cgroup/" + name_group + "/cgroup.procs /sys/fs/cgroup/cgroup.subtree_control /sys/fs/cgroup/cgroup.procs";
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);
    
    //exec App
    string combined_exec = "cgexec -g cpu,memory:" + name_group + " " + program_exec;
    command = combined_exec.c_str();
    cout << command << endl;
    system(command);
    
    return 0;
}