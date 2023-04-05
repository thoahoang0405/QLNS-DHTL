<template>
    <div class="notification-wrap">
        <div class="notificationn">
            <div class="warringgg">
                <div>
                    <div class="icon-warning"></div>
                </div>



                <div class="warrning-title">{{ msg }}</div>
            </div>
            <div class="btn-wrap">

                <div class=" btn-primary" @click="noClick">Đóng</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            // isShowNotifi: false
            msvDl: "",
        }
    },
    props: ["msg"],
    components: {
    },
    watch: {
        msv: function (value) {
            this.msvDl = value
        }
    },

    methods: {
        noClick() {
            //đồng ý xóa
            this.$emit('closePopUpWarning', false)
        },

    }
}
</script>
<style>
.notification-wrap {
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 4;
    width: 100%;
    height: 100%;
    margin: auto;
    position: fixed;
    display: flex;

}

.notificationn {
    z-index: 3;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    background-color: #fff;
    width: 358px;
    height: 150px;
    padding: 20px;
    border-radius: 2px;
    box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
}

.warringgg {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 30px;
}

/* .icon-warning {
            width: 52px;
    } */
.warringgg i {
    font-size: 60px;
    width: 44px;
    height: 40px;
    color: #F4A733;
}

.warrning-title {
    text-align: center;
    font-size: 16px;
    margin-left: 8px;
}

.btn-wrap {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    column-gap: 20px;
}

.btnNotifi {
    display: flex;
    width: 100px;
    align-items: center;
    justify-content: center;
    margin-top: 38px;
    border-radius: 2px;
    cursor: pointer;
    color: #1A8FDD;
    height: 34px;
    box-sizing: border-box;

}

.btnNotifi:hover {
    opacity: 0.8;
    background-color: #1A8FDD;
    color: #fff;
    border: 1px solid #1A8FDD;
}

.btn-primary:hover {
    background-color: #fff;
    color: #1A8FDD;
    border: 1px solid #1A8FDD;
}

.btn-primary {
    height: 34px;
    margin-right: 40px;
    background-color: #1A8FDD;
    color: #fff;
    display: flex;
    width: 100px;
    align-items: center;
    justify-content: center;
    margin-top: 38px;
    border-radius: 2px;
    box-sizing: border-box;
    cursor: pointer;
}

@media screen and (max-width: 767.98px) {
    .notification {
        font-size: 15px;
        width: 300px;
        height: 130px;
        padding: 14px;
    }

    .warring {
        margin-top: 6px;
    }


    .btnNotifi {
        width: 80px;
        margin-top: 20px;
    }
}</style>