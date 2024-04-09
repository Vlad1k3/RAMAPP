
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

    const string create_group_prompt = "sudo cgcreate -g cpu,memory:";
    string create_group_combined;
    string setup_combined;
    const string prompt_setup = "sudo cgset -r memory.max=";
    const string prompt_exec = "cgexec -g cpu,memory:";
    const string flags_exec = "--no-sandbox --user-data-dir";
    const string prompt_owner = "sudo chown ssofixd";
    const string first_group_owner = " /sys/fs/cgroup";
    const string second_group_owner = "/cgroup.subtree_control /sys/fs/cgroup";
    string combined_exec;

    const char* command = nullptr;

    // create group
    create_group_combined =create_group_prompt + name_group + " && " + prompt_setup + ""+ count_MB +"M " + name_group;
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);

    //owner group
    create_group_combined = prompt_owner + first_group_owner + "/" + name_group + second_group_owner + "/" + name_group + "/cgroup.procs" + first_group_owner + second_group_owner + "/cgroup.procs";
    command = create_group_combined.c_str();
    cout << command << endl;
    system(command);

    combined_exec = prompt_exec + name_group + " " + program_exec;
    command = combined_exec.c_str();
    cout << command << endl;
    system(command);
    
    return 0;
}