<template>
  <div class="justify-content-center mx-5">
    <div class="input-group">
      <button
        type="button"
        class="btn btn-primary m-2 fload-end"
        data-bs-toggle="modal"
        data-bs-target="#inputModal"
        @click="addClick()"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="16"
          height="16"
          fill="currentColor"
          class="bi bi-plus-square"
          viewBox="0 0 16 16"
        >
          <path
            d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"
          />
          <path
            d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"
          />
        </svg>
      </button>
      <div class="mx-3 pt-2">
        <h4>{{ ja_Job }}</h4>
      </div>
    </div>
    <!--▼業務件数テーブルデータ▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼-->
    <table class="table table-striped">
      <thead>
        <tr>
          <th>{{ ja_Employee }}</th>
          <th>{{ ja_Department }}</th>
          <th>{{ ja_TotalJobs }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="dat in jobs" :key="dat.jobId">
          <td
            data-bs-toggle="modal"
            data-bs-target="#employeeJobModal"
            @click="getTargetEmployeeName(dat.employeeName)"
          >
            {{ dat.employeeName }}
          </td>
          <td
            data-bs-toggle="modal"
            data-bs-target="#employeeJobModal"
            @click="getTargetEmployeeName(dat.employeeName)"
          >
            {{ dat.employeeDepartment }}
          </td>
          <td
            data-bs-toggle="modal"
            data-bs-target="#employeeJobModal"
            @click="getTargetEmployeeName(dat.employeeName)"
          >
            {{ dat.jobContent }}
          </td>
        </tr>
      </tbody>
    </table>
    <!--▲業務件数テーブルデータ▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲-->
    <!--▼データ編集MODAL▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼-->
    <input-modal-view
      :Title="modalTitle"
      :Id="JobId"
      @createData="createClick"
      @updateData="updateClick"
    >
      <template v-slot:modalBody>
        <div class="modal-body">
          <div class="input-group mb-3">
            <span class="input-group-text">{{ ja_Employee }}</span>
            <select
              class="form-control"
              v-model="EmployeeNameSelect"
              @change="getDepartment()"
            >
              <option value="-" selected>-</option>
              <option
                v-for="option in employeeList"
                :key="option.employeeId"
                :value="option.name + '_' + option.department"
              >
                {{ option.name }}
              </option>
              >
            </select>
            <span class="input-group-text">{{ ja_Department }}</span>
            <input
              type="text"
              class="form-control"
              v-model="EmployeeDepartment"
            />
          </div>
          <div class="input-group mb-3">
            <span class="input-group-text">{{ ja_DueDate }}</span>
            <input type="text" class="form-control" v-model="DueDate" />
            <span class="input-group-text">{{ ja_Status }}</span>
            <input type="text" class="form-control" v-model="Status" />
          </div>
          <div class="input-group">
            <span class="input-group-text">{{ ja_Content }}</span>
            <input type="text" class="form-control" v-model="JobContent" />
          </div>
        </div>
      </template>
    </input-modal-view>
    <!--▲データ編集MODAL▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲-->
    <!--▼社員業務一覧Modal▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼-->
    <div
      class="modal fade"
      id="employeeJobModal"
      tabindex="-1"
      aria-labelledby="exampleModalLable"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              {{ EmployeeTargetName }} {{ ja_Job }}
            </h5>
            <button
              id="modal-closeDetail-btn"
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              arial-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <table class="table table-striped">
              <thead>
                <tr>
                  <th>{{ ja_Employee }}</th>
                  <th>{{ ja_Content }}</th>
                  <th>{{ ja_DueDate }}</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="dat in employeeJobs" :key="dat.jobId">
                  <td>{{ dat.employeeName }}</td>
                  <td>{{ dat.jobContent }}</td>
                  <td>{{ dat.dueDate }}</td>
                  <td>
                    <button
                      type="button"
                      class="btn btn-light mr-1"
                      data-bs-toggle="modal"
                      data-bs-target="#inputModal"
                      @click="editClick(dat)"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        class="bi bi-pencil-fill"
                        viewBox="0 0 16 16"
                      >
                        <path
                          d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z"
                        />
                      </svg>
                    </button>
                    <button
                      type="button"
                      class="btn btn-light mr-1"
                      @click="deleteJobClick(dat.jobId)"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        class="bi bi-trash"
                        viewBox="0 0 16 16"
                      >
                        <path
                          fill-rule="evenodd"
                          d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
                        />
                      </svg>
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <!--▲社員業務一覧Modal▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲-->
  </div>
</template>
<script>
import url from "../assets/js/url.js";
import axios from "axios";
import ja from "../locales/ja.json";
import InputModalView from "./InputModalView.vue";
// dummy data
import dummy from "../assets/dummy.json";

export default {
  components: {
    InputModalView,
  },
  data() {
    return {
      ja_Job: ja.Job,
      ja_Employee: ja.Employee,
      ja_Department: ja.Department,
      ja_Content: ja.Content,
      ja_DueDate: ja.DueDate,
      ja_Status: ja.Status,
      ja_TotalJobs: ja.TotalJobs,
      modalTitle: ja.New,
      employeeList: [],
      jobs: [],
      employeeJobs: [],
      JobId: 0,
      EmployeeName: "-",
      EmployeeTargetName: "-",
      EmployeeNameSelect: "-_-",
      EmployeeDepartment: "-",
      JobContent: "-",
      DueDate: this.currentDate(),
      Status: ja.DefaultStatus,
    };
  },
  methods: {
    addClick() {
      this.modalTitle = ja.New;
      this.JobId = 0;
      this.EmployeeName = "-";
      this.EmployeeDepartment = "-";
      this.Content = "-";
      this.DueDate = this.currentDate();
      this.Status = ja.DefaultStatus;
    },
    createClick() {
      axios
        .post(url.API_URL + "Job/create-job", {
          EmployeeName: this.EmployeeName,
          EmployeeDepartment: this.EmployeeDepartment,
          JobContent: this.JobContent,
          DueDate: this.DueDate,
          Status: this.Status,
        })
        .then(() => {
          document.getElementById("modal-close-btn").click();
          this.refreshData();
        })
        .catch((error) => {
          alert("No Connection " + error);
        });
    },
    currentDate() {
      const current = new Date();
      const date =
        current.getFullYear() +
        "-" +
        (current.getMonth() + 1) +
        "-" +
        current.getDate();
      return date;
    },
    deleteJobClick(id) {
      if (!confirm(ja.ConfirmDelete)) {
        return;
      }
      axios
        .delete(url.API_URL + "Job/delete-job-by-id/" + id)
        .then(() => {
          document.getElementById("modal-closeDetail-btn").click();
          this.refreshData();
        })
        .catch((error) => {
          alert("No Connection " + error);
        });
    },
    editClick(dat) {
      this.modalTitle = ja.Edit;
      this.JobId = dat.jobId;
      this.EmployeeName = dat.employeeName;
      this.EmployeeNameSelect = dat.employeeName + "_" + dat.employeeDepartment;
      this.EmployeeDepartment = dat.employeeDepartment;
      this.Content = dat.jobContent;
      this.DueDate = dat.dueDate;
      this.Status = dat.status;
    },
    getEmployeeList() {
      axios
        .get(url.API_URL + "Employee/read-all-employees")
        .then((response) => {
          this.employeeList = response.data;
        });
    },
    getDepartment() {
      var val = this.EmployeeNameSelect.split("_");
      this.EmployeeName = String(val.slice(0, 1));
      this.EmployeeDepartment = String(val.slice(1, 2));
    },
    getTargetEmployeeName(employeeName) {
      this.EmployeeTargetName = employeeName;
      const self = this;
      this.employeeJobs = [];
      axios
        .get(url.API_URL + "Job/read-all-employee-jobs/" + employeeName)
        .then((response) => {
          self.employeeJobs = response.data;
        })
        .catch((error) => {
          console.log(error);
          // 接続がない場合、ダミーデータが使用されます
          dummy[0].jobs.forEach((e) => {
            if (e.employeeName == employeeName) {
              self.employeeJobs.push(e);
            }
          });
        });
    },
    refreshData() {
      const self = this;
      axios
        .get(url.API_URL + "Job/read-total-jobs-employee")
        .then((response) => {
          self.jobs = response.data;
        })
        .catch((error) => {
          console.log(error);
          // 接続がない場合、ダミーデータが使用されます
          self.jobs = dummy[0].jobscount;
        });
    },
    updateClick() {
      axios
        .put(url.API_URL + "Job/update-job-by-id/", {
          JobId: this.JobId,
          EmployeeName: this.EmployeeName,
          EmployeeDepartment: this.EmployeeDepartment,
          JobContent: this.JobContent,
          DueDate: this.DueDate,
          Status: this.Status,
        })
        .then(() => {
          document.getElementById("modal-close-btn").click();
          this.refreshData();
        })
        .catch((error) => {
          alert("No Connection " + error);
        });
    },
  },
  mounted: function () {
    this.getEmployeeList();
    this.refreshData();
  },
};
</script>
<style scoped>
.modal-header {
  background-color: #cae4ba;
}
</style>
