<template>
  <navBar></navBar>
  <div class="container loginBox">
    <div class="loginText">
      <h4>Flex Your Journey. Join us!</h4>
    </div>
    <div class="from-group" v-if="errors.length">
      <ul class="mb-3 errsText">
        <span v-for="error in errors" class="text-danger">{{ error }}</span>
      </ul>
    </div>
    <div class="from-group mb-3">
      <input
        type="text"
        name="account"
        v-if="accInput"
        v-model="account"
        class="form-control"
        placeholder="手機號碼/帳號/Email"
      />
    </div>
    <div class="from-group mb-3" v-if="validated">
      <label class="mb-1">密碼</label>
      <input
        type="password"
        name="password"
        v-model="password"
        class="form-control"
        placeholder="輸入6-20碼英數字"
      />
    </div>
    <div class="from-group mb-3" v-if="unValidated">
      <label>信箱</label>
      <input
        type="email"
        name="email"
        class="form-control"
        placeholder="信箱"
      />
    </div>
    <div class="from-group mb-3">
      <button
        type="submit"
        class="btn logAndRegBtn"
        v-if="registered"
        v-show="logAndRegBtn"
        @click="ValidatedIdentity"
      >
        登入 / 註冊
      </button>
      <button
        type="submit"
        class="btn logBtn"
        @click="Login"
        v-if="!registered"
      >
        登入
      </button>
      <button
        type="submit"
        class="btn btn-danger registerBtn"
        @click="register"
        v-if="unRegistered"
      >
        註冊
      </button>
    </div>
    <div>
      <p>或</p>
    </div>
    <div class="from-group mb-3">
      <button
        type="submit"
        class="btn btn-info googleBtn"
        @click="ValidatedIdentity"
      >
        我是假的google登入
      </button>
    </div>
  </div>
</template>

<script setup>
import axios from 'axios';
import navBar from '@/components/home/navBar.vue';
import { ref } from 'vue';

const errors = ref([]);
const userData = ref([]);
const accInput = ref(true);
const validated = ref(false); //初始化狀態為不顯示
const unValidated = ref(false);
const logAndRegBtn = ref(true);
const registered = ref(true);
const unRegistered = ref(false);

const account = ref('');
const password = ref('');

const baseAddress = 'https://localhost:7183';
const uri = `${baseAddress}/api/Users/Login`;
var loginData = {}; //儲存傳給後端的登入資料

function ValidatedIdentity() {
  //alert('loginAndRegister');
  //未填寫
  if (account.value === '') {
    errors.value = [];
    errors.value.push('沒有填誰知道你是誰');
  } else {
    //已填寫
    errors.value = [];
    loginData.Account = account.value;
    //console.log(loginData.Account.value);

    axios
      .post(uri, loginData)
      .then((res) => {
        userData.value = res.data;
        //console.log(userData.value); //後端return的訊息

        //從回傳的資料中取得帳號並進行比較
        //已註冊
        if (userData.value === account.value) {
          //console.log('帳號驗證成功囉!');
          validated.value = true;
          accInput.value = false;
          registered.value = false;
        } else {
          //未註冊
          validated.value = false;
          //console.log('帳號驗證失敗');
          logAndRegBtn.value = false;
          unValidated.value = true;
          unRegistered.value = true;
          //todo驗證帳號是否唯一
          //todo寄信
        }
      })
      .catch((err) => {
        alert('API請求失敗：' + err.message);
      });
  }
}

function Login() {
  //alert('Login');
  //todo是否與資料庫的密碼相符
  loginData.EncryptedPassword = password.value;
  //console.log(loginData);

  //未填寫密碼
  if (password.value === '') {
    errors.value = [];
    errors.value.push('密碼沒有填想怎樣');
    return;
  }

  axios
    .post(uri, loginData)
    .then((res) => {
      const jsonData = res.data;
      const userPassword = jsonData.find(
        (claim) => claim.Type === 'UserPassword'
      );
      //console.log(userPassword.Value);

      if (userPassword.Value === password.value) {
        //密碼正確
        errors.value = [];
        //errors.value.push('密碼正確');
        //console.log(userPassword.Value);
        const userName = jsonData.find((claim) => claim.Type === 'FullName');
        console.log(userName.Value);
        //alert('登入成功啦港動~~~');
      }
    })
    .catch((err) => {
      errors.value = [];
      errors.value.push('密碼錯誤');
      //todo錯誤累計三次
    });
}

function register() {
  //alert('register');
  //todo檢查信箱格式
  //todo是否與資料庫的信箱一樣，信箱已經註冊過囉
}
</script>
<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Lilita+One&display=swap');
.loginBox {
  width: 23%;
  justify-content: center;
  align-items: center;
  padding: 45px;
  margin-top: 80px;
}
.loginText {
  display: flex;
  justify-content: center;
}
.loginText > h4 {
  font-family: 'Bebas Neue', sans-serif;
  font-weight: bold;
  font-size: 40px;
}
.errsText {
  display: flex;
  justify-content: center;
  padding: 0px;
  margin: 0px;
}
.logAndRegBtn {
  width: 100%;
  margin: auto;
  background-color: black;
  color: white;
}
.logBtn {
  width: 100%;
  margin: auto;
  background-color: black;
  color: white;
}
.googleBtn {
  width: 100%;
}
p {
  position: relative;
  text-align: center; /* 將文字置於中間 */
}

p::before,
p::after {
  content: '';
  position: absolute;
  top: 50%;
  width: 150px; /* 調整線段的長度 */
  height: 1px; /* 調整線段的粗細 */
  background-color: black; /* 設定線段的顏色 */
}

p::before {
  left: 0;
}

p::after {
  right: 0;
}
</style>
