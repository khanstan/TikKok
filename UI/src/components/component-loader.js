import Vue from 'vue'
import HelloWorld from './HelloWorld.vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

const components = [
    {
        component: HelloWorld,
        element: 'hello-world'
    },
];

export default {
    loadComponents() {
        components.forEach(({ component, element }) => {
            // Is the custom element in the DOM?
            if (!document.querySelector(element)) {
                return;
            }

            // Create a new Vue instance and mount it to the custom element.
            new Vue({
                render: createElement => createElement(component)
            }).$mount(element);
        });
    }
}