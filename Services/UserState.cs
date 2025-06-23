using System.Text.Json;
using Microsoft.JSInterop;
using Frontend.Models;

namespace Frontend.Services {
    public class UserState {
        // In-memory current user
        public User? CurrentUser { get; set; }
        
        // locallStorage access via JS
        private readonly IJSRuntime _js;
        public UserState(IJSRuntime js){_js = js;}
        
        // Load user on startup
        public async Task Initialize() {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", "user");
            if (!string.IsNullOrEmpty(json))
                CurrentUser = JsonSerializer.Deserialize<User>(json);
        }
        
        // Save on login
        public async Task Login(User user) {
            CurrentUser = user;
            await _js.InvokeVoidAsync("localStorage.setItem", "user", JsonSerializer.Serialize(user));
        }
        
        // Clear on logout
        public async Task Logout() {
            CurrentUser = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", "user");
        }

        // Check if user is logged in
        public bool IsLoggedIn => CurrentUser != null;
    }
}
